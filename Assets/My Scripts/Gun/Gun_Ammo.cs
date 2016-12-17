using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Gun_Ammo : MonoBehaviour
    {
        private Player_Master playerMaster;
        private Gun_Master gunMaster;
        private Player_AmmoBox ammoBox;
        private Animator myAnimator;

        public int clipSize;
        public int currentAmmo;
        public string ammoName;
        public float reloadTime;

        void OnEnable()
        {
            SetInitialReferences();
            StartingSanityCheck();
            CheckAmmoStatus();

            gunMaster.EventPlayerInput += DeductAmmo;
            gunMaster.EventPlayerInput += CheckAmmoStatus;
            gunMaster.EventRequestReload += TryToReload;
            gunMaster.EventGunNotUsable += TryToReload;
            gunMaster.EventRequestGunReset += ResetGunReloading;

            if(playerMaster != null)
            {
                playerMaster.EventAmmoChanged += UIAmmoUpdateRequest;
            }

            if(ammoBox != null)
            {
                StartCoroutine(UpdateAmmoUIWhenEnabling());
            }
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= DeductAmmo;
            gunMaster.EventPlayerInput -= CheckAmmoStatus;
            gunMaster.EventRequestReload -= TryToReload;
            gunMaster.EventGunNotUsable -= TryToReload;
            gunMaster.EventRequestGunReset -= ResetGunReloading;

            if (playerMaster != null)
            {
                playerMaster.EventAmmoChanged -= UIAmmoUpdateRequest;
            }
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();

            if(GetComponent<Animator>() != null)
            {
                myAnimator = GetComponent<Animator>();
            }

            if(GameManager_References._player != null)
            {
                playerMaster = GameManager_References._player.GetComponent<Player_Master>();
                ammoBox = GameManager_References._player.GetComponent<Player_AmmoBox>();
            }
        }

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
            StartCoroutine(UpdateAmmoUIWhenEnabling());

            if (playerMaster != null)
            {
                playerMaster.EventAmmoChanged += UIAmmoUpdateRequest;
            }
        }

        void DeductAmmo()
        {
            currentAmmo--;
            UIAmmoUpdateRequest();
        }

        void TryToReload()
        {
            for(int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
            {
                if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
                {
                    if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried > 0 && currentAmmo != clipSize && !gunMaster.isReloading)
                    {
                        gunMaster.isReloading = true;
                        gunMaster.isGunLoaded = false;

                        if(myAnimator != null)
                        {
                            myAnimator.SetTrigger("reload");
                        }
                        else
                        {
                            StartCoroutine(ReloadWithoutAnimation());
                        }
                    }
                    break;
                }
            }
        }

        void CheckAmmoStatus()
        {
            if(currentAmmo <= 0)
            {
                currentAmmo = 0;
                gunMaster.isGunLoaded = false;
            }
            else if(currentAmmo > 0)
            {
                gunMaster.isGunLoaded = true;
            }
        }

        void StartingSanityCheck()
        {
            if(currentAmmo > clipSize)
            {
                currentAmmo = clipSize;
            }
        }

        void UIAmmoUpdateRequest()
        {
            for(int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
            {
                if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
                {
                    gunMaster.CallEventAmmoChanged(currentAmmo, ammoBox.typesOfAmmunition[i].ammoCurrentCarried);
                    break;
                }
            }
        }

        void ResetGunReloading()
        {
            gunMaster.isReloading = false;
            CheckAmmoStatus();
            UIAmmoUpdateRequest();
        }

        public void OnReloadComplete()
        {
            for(int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
            {
                if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
                {
                    int ammoTopUp = clipSize - currentAmmo;

                    if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried >= ammoTopUp)
                    {
                        currentAmmo += ammoTopUp;
                        ammoBox.typesOfAmmunition[i].ammoCurrentCarried -= ammoTopUp;
                    }
                    else if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried < ammoTopUp && ammoBox.typesOfAmmunition[i].ammoCurrentCarried != 0)
                    {
                        currentAmmo += ammoBox.typesOfAmmunition[i].ammoCurrentCarried;
                        ammoBox.typesOfAmmunition[i].ammoCurrentCarried = 0;
                    }
                    break;
                }
            }

            ResetGunReloading();
        }

        IEnumerator ReloadWithoutAnimation()
        {
            yield return new WaitForSeconds(reloadTime);
            OnReloadComplete();
        }

        IEnumerator UpdateAmmoUIWhenEnabling()
        {
            yield return new WaitForSeconds(0.05f);
            UIAmmoUpdateRequest();
        }
    }
}


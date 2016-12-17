using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Gun_MuzzleFlash : MonoBehaviour
    {
        private Gun_Master gunMaster;
        public ParticleSystem muzzleFlash;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += PlayMuzzleFlash;
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= PlayMuzzleFlash;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void PlayMuzzleFlash()
        {
            if(muzzleFlash != null)
            {
                muzzleFlash.Play();
            }
        }
    }
}


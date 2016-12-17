using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Gun_Master : MonoBehaviour
    {
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventPlayerInput;
        public event GeneralEventHandler EventGunNotUsable;
        public event GeneralEventHandler EventRequestReload;
        public event GeneralEventHandler EventRequestGunReset;
        //public event GeneralEventHandler EventToggleBurstFire;

        public delegate void GunHitEventHandler(Vector3 hitPosition, Transform hitTransform);
        public event GunHitEventHandler EventShotDefault;
        public event GunHitEventHandler EventShotEnemy;

        public delegate void GunAmmoEventHandler(int currentAmmo, int carriedAmmo);
        public event GunAmmoEventHandler EventAmmoChanged;

        public delegate void GunCrosshairEventHandler(float speed);
        public event GunCrosshairEventHandler EventSpeedCaptured;

        public bool isGunLoaded;
        public bool isReloading;

        public void CallEventPlayerInput()
        {
            if(EventPlayerInput != null)
            {
                EventPlayerInput();
            }
        }

        public void CallEventGunNotUsable()
        {
            if (EventGunNotUsable != null)
            {
                EventGunNotUsable();
            }
        }

        public void CallEventRequestReload()
        {
            if (EventRequestReload != null)
            {
                EventRequestReload();
            }
        }

        public void CallEventRequestGunReset()
        {
            if (EventRequestGunReset != null)
            {
                EventRequestGunReset();
            }
        }

        //public void CallEventToggleBurstFire()
        //{
        //    if (EventToggleBurstFire != null)
        //    {
        //        EventToggleBurstFire();
        //    }
        //}

        public void CallEventShotDefault(Vector3 hPos, Transform hTransform)
        {
            if (EventShotDefault != null)
            {
                EventShotDefault(hPos, hTransform);
            }
        }

        public void CallEventShotEnemy(Vector3 hPos, Transform hTransform)
        {
            if (EventShotEnemy != null)
            {
                EventShotEnemy(hPos, hTransform);
            }
        }

        public void CallEventAmmoChanged(int curAmmo, int carAmmo)
        {
            if (EventAmmoChanged != null)
            {
                EventAmmoChanged(curAmmo, carAmmo);
            }
        }

        public void CallEventSpeedCaptured(float spd)
        {
            if (EventSpeedCaptured != null)
            {
                EventSpeedCaptured(spd);
            }
        }
    }

}

using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Gun_ApplyDamage : MonoBehaviour
    {
        private Gun_Master gunMaster;
        public int damage = 10;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventShotEnemy += ApplyDamage;
        }

        void OnDisable()
        {
            gunMaster.EventShotEnemy -= ApplyDamage;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void ApplyDamage(Vector3 hitPosition, Transform hitTransform)
        {
            if(hitTransform.GetComponent<Enemy_TakeDamage>() != null)
            {
                hitTransform.GetComponent<Enemy_TakeDamage>().ProcessDamage(damage);
            }
        }
    }
}


using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Enemy_CollisionField : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Rigidbody rigidbodyStrikingMe;
        private int damageToApply;
        public float massRequirement = 50f;
        public float speedRequirement = 5f;
        private float damageFactor = 0.1f;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
        }

        void SetInitialReferences()
        {
            enemyMaster = transform.root.GetComponent<Enemy_Master>();
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Rigidbody>() != null)
            {
                rigidbodyStrikingMe = other.GetComponent<Rigidbody>();

                if(rigidbodyStrikingMe.mass >= massRequirement && rigidbodyStrikingMe.velocity.sqrMagnitude > speedRequirement * speedRequirement)
                {
                    damageToApply = (int)(damageFactor * rigidbodyStrikingMe.mass * rigidbodyStrikingMe.velocity.magnitude);
                    enemyMaster.CallEventEnemyDeductHealth(damageToApply);
                }
            }
        }

        void DisableThis()
        {
            gameObject.SetActive(false);
        }
    }
}



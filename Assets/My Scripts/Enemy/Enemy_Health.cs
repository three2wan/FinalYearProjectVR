using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Enemy_Health : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        public int enemyHealth = 100;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDeductHealth += DeductHealth;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDeductHealth -= DeductHealth;
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
        }

        void DeductHealth(int healthChange)
        {
            enemyHealth -= healthChange;

            if(enemyHealth <= 0)
            {
                enemyHealth = 0;
                enemyMaster.CallEventEnemyDie();
                Destroy(gameObject, Random.Range(1f, 1.5f));
            }
        }
    }
}


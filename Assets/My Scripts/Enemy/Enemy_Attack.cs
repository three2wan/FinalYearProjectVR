using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Enemy_Attack : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Transform attackTarget;
        private Transform myTransform;
        public float attackRate = 1f;
        private float nextAttack;
        public float attackRange = 3.5f;
        public int attackDamage = 10;
        
        void OnEnable()
        {
            SetInitialReference();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
        }

        // Update is called once per frame
        void Update()
        {
            TryToAttack();
        }

        void SetInitialReference()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            myTransform = transform;
        }

        void SetAttackTarget(Transform targetTransform)
        {
            attackTarget = targetTransform;
        }

        void TryToAttack()
        {
            if(attackTarget != null)
            {
                if(Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    if(Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange)
                    {
                        Vector3 lookAtVector = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                        myTransform.LookAt(lookAtVector);
                        enemyMaster.CallEventEnemyAttack();
                        enemyMaster.isOnRoute = false;
                    }
                }
            }
        }

        public void OnEnemyAttack() //Called by attack animation
        {
            if(attackTarget != null)
            {
                if(Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange && attackTarget.GetComponent<Player_Master>() != null)
                {
                    Vector3 toOther = attackTarget.position - myTransform.position;
                    
                    if(Vector3.Dot(toOther, myTransform.forward) > 0.5f)
                    {
                        attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDeduction(attackDamage);
                    }
                }
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }
    }
}


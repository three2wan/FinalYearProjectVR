using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Item_Health : MonoBehaviour
    {
        private Item_Master itemMaster;
        private GameObject playerGO;
        public int quantity;
        public bool isTriggerPickup;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectPickup += TakeHealth;
        }

        void OnDisable()
        {
            itemMaster.EventObjectPickup -= TakeHealth;
        }

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
            playerGO = GameManager_References._player;

            if (isTriggerPickup)
            {
                if (GetComponent<Collider>() != null)
                {
                    GetComponent<Collider>().isTrigger = true;
                }

                if (GetComponent<Rigidbody>() != null)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameManager_References._playerTag) && isTriggerPickup)
            {
                TakeHealth();
            }
        }

        void TakeHealth()
        {
            playerGO.GetComponent<Player_Master>().CallEventPlayerHealthIncrease(quantity);
            Destroy(gameObject);
        }
    }

}


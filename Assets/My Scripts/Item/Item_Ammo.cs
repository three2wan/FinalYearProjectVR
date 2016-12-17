﻿using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Item_Ammo : MonoBehaviour
    {
        private Item_Master itemMaster;
        private GameObject playerGO;
        public string ammoName;
        public int quantity;
        public bool isTriggerPickup;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectPickup += TakeAmmo;
        }

        void OnDisable()
        {
            itemMaster.EventObjectPickup -= TakeAmmo;
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
                if(GetComponent<Collider>() != null)
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
            if(other.CompareTag(GameManager_References._playerTag) && isTriggerPickup)
            {
                TakeAmmo();
            }
        }

        void TakeAmmo()
        {
            playerGO.GetComponent<Player_Master>().CallEventPickedUpAmmo(ammoName, quantity);
            Destroy(gameObject);
        }
    }
}


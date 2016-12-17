using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Item_Pickup : MonoBehaviour
    {
        private Item_Master itemMaster;
       
        void OnEnable()
        {
            SetInitReferences();
            itemMaster.EventPickupAction += CarryOutPickupActions;
        }

        void OnDisable()
        {
            itemMaster.EventPickupAction -= CarryOutPickupActions;
        }

        void SetInitReferences()
        {
            itemMaster = GetComponent<Item_Master>();
        }

        void CarryOutPickupActions(Transform tParent)
        {
            transform.SetParent(tParent);
            itemMaster.CallEventObjectPickup();
            transform.gameObject.SetActive(false);
        }
    }
}



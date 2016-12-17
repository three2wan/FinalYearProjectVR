using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class TriggerZombie : MonoBehaviour
    {
        public GameObject zombieTrigger;

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                zombieTrigger.SetActive(true);
            }
            
        }
    }
}


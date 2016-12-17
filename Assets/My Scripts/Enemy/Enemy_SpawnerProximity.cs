using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Enemy_SpawnerProximity : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public int numberToSpawn;
        public float proximity;
        private float checkRate;
        //private float nextCheck;
        private Transform myTransform;
        private Transform playerTransform;
        private Vector3 spawnPosition;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckDistance();
        }

        void SetInitialReferences()
        {
            myTransform = transform;
            playerTransform = GameManager_References._player.transform;
            checkRate = Random.Range(0.8f, 1.2f);
        }

        void CheckDistance()
        {
            if(Time.time > checkRate)
            {
                //nextCheck = Time.time + checkRate;

                if(Vector3.Distance(myTransform.position, playerTransform.position) < proximity)
                {
                    SpawnObjects();
                    this.enabled = false;
                }
            }
        }

        void SpawnObjects()
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                spawnPosition = myTransform.position + Random.insideUnitSphere * 5;
                Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
            }
        }
    }
}


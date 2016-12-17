using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class Gun_Shoot : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private Transform myTransform;
        private Transform camTransform;
        private RaycastHit hit;
        public float range = 400;
        private float offsetFactor = 7;
        private Vector3 startPosition;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += OpenFire;
            gunMaster.EventSpeedCaptured += SetStartOfShootingPosition;
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= OpenFire;
            gunMaster.EventSpeedCaptured -= SetStartOfShootingPosition;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            myTransform = transform;
            camTransform = myTransform.parent;
        }

        void OpenFire()
        {
            if(Physics.Raycast(camTransform.TransformPoint(startPosition), camTransform.forward, out hit, range))
            {
                gunMaster.CallEventShotDefault(hit.point, hit.transform);

                if (hit.transform.CompareTag(GameManager_References._enemyTag))
                {
                    gunMaster.CallEventShotEnemy(hit.point, hit.transform);
                }
            }
        }

        void SetStartOfShootingPosition(float playerSpeed)
        {
            float offset = playerSpeed / offsetFactor;
            startPosition = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 1);
        }
    }
}


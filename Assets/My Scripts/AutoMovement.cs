using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class AutoMovement : MonoBehaviour
    {
        public Transform[] movementPoint;
        public float moveSpeed;
        private int currentPoint;

        // Use this for initialization
        void Start()
        {
            transform.position = movementPoint[0].position;
            currentPoint = 0;  
        }

        // Update is called once per frame
        void Update()
        {
            AutomateMovement();
        }

        void AutomateMovement()
        {
            if (Input.GetButton("PS4_L2"))
            {
                if (transform.position == movementPoint[currentPoint].position)
                {
                    currentPoint++;
                }

                if (currentPoint >= movementPoint.Length)
                {
                    currentPoint = movementPoint.Length - 1;
                }

                transform.position = Vector3.MoveTowards(transform.position, movementPoint[currentPoint].position, moveSpeed * Time.deltaTime);
            }
        }
    }

}

using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class PlayerSurvive : MonoBehaviour
    {
        public Transform goalPosition;
        public GameObject winningPanel;

        void Update()
        {
            if(transform.position == goalPosition.transform.position)
            {
                winningPanel.SetActive(true);
            }
        }       
    }
}


using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class GameManager_GameWin : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject playerPosition;
        public GameObject panelSurvive;
        public GameObject CanvasMenu;
        public Transform goalPosition;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GameWinEvent += TurnOnSurvivePanel;
        }

        void OnDisable()
        {
            gameManagerMaster.GameWinEvent -= TurnOnSurvivePanel;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void Update()
        {
            TurnOnSurvivePanel();
        }

        void TurnOnSurvivePanel()
        {
            if (playerPosition.transform.position == goalPosition.transform.position)
            {
                if (panelSurvive != null)
                {
                    panelSurvive.SetActive(true);
                }
            } 
        }
    }
}


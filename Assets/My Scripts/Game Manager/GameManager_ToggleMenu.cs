using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject menu;

        // Use this for initialization
        void Start()
        {
            //ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }

        void OnEnable()
        {
            SetInitialreferences();
            gameManagerMaster.GameOverEvent += ToggleMenu;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void SetInitialreferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            //key press to bring up menu
            if(Input.GetButtonDown("PS4_Options") && !gameManagerMaster.isGameOver && !gameManagerMaster.isGameWin/*&& !gameManagerMaster.isInventoryUIOn*/)
            {
                ToggleMenu();
            }
        }

        public void ToggleMenu()
        {
            if(menu != null)
            {
                menu.SetActive(!menu.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallEventMenuToggle();
            }
        }
    }
}



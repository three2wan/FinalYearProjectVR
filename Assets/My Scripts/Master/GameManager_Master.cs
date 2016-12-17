using UnityEngine;
using System.Collections;

namespace DeadEnd
{
    public class GameManager_Master : MonoBehaviour
    {
        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        //public event GameManagerEventHandler InventoryUIToggleEvent;
        public event GameManagerEventHandler RestartLevelEvent;
        public event GameManagerEventHandler GoToMenuSceneEvent;
        public event GameManagerEventHandler GameOverEvent;
        public event GameManagerEventHandler GameWinEvent;

        public bool isGameOver;
        public bool isGameWin;
        //public bool isInventoryUIOn;
        public bool isMenuOn;
        
        public void CallEventMenuToggle()
        {
            if(MenuToggleEvent != null)
            {
                MenuToggleEvent();
            }
        }

        //public void CallInventoryUIToggle()
        //{
        //    if(InventoryUIToggleEvent != null)
        //    {
        //        InventoryUIToggleEvent();
        //    }
        //}

        public void CallEventRestartLevel()
        {
            if (RestartLevelEvent != null)
            {
                RestartLevelEvent();
            }
        }

        public void CallEventGoToMenuScene()
        {
            if (GoToMenuSceneEvent != null)
            {
                GoToMenuSceneEvent();
            }
        }

        public void CallEventGameOver()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }

        public void CallEventGameWin()
        {
            if(GameWinEvent != null)
            {
                isGameWin = true;
                GameWinEvent();
            }
        }

    }
}


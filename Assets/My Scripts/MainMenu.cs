using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace DeadEnd
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject quitPanel;
        public GameObject mainMenuPanel;
        public GameObject playPanel;
        public GameObject settingPanel;

        public void PlayGame()
        {
            playPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
        
        public void SettingGame()
        {
            settingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void ExitGame()
        {
            mainMenuPanel.SetActive(false);
            quitPanel.SetActive(true);
        }

        public void YesExit()
        {
            Application.Quit();
        }

        public void NoExit()
        {
            mainMenuPanel.SetActive(true);
            quitPanel.SetActive(false);
        }

        public void BackButton()
        {
            playPanel.SetActive(false);
            settingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        public void PlayMission1()
        {
            SceneManager.LoadScene("Level1");
        }

        public void PlayMission2()
        {
            SceneManager.LoadScene("Level2");
        }
    }
}


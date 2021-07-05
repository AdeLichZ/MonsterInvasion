using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject titlesPanel;
        [SerializeField] GameObject HighScorePanel;
        void Start()
        {
            Time.timeScale = 1;
            mainMenu.SetActive(true);
            titlesPanel.SetActive(false);
            HighScorePanel.SetActive(false);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
        public void ToMenu()
        {
            titlesPanel.SetActive(false);
            HighScorePanel.SetActive(false);
            mainMenu.SetActive(true);
        }
        public void ToTitles()
        {
            mainMenu.SetActive(false);
            titlesPanel.SetActive(true);
        }
        public void ToScores()
        {
            mainMenu.SetActive(false);
            HighScorePanel.SetActive(true);
        }
        public void OnApplicationQuit()
        {
            Application.Quit();
        }
    }
}

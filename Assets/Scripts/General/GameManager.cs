using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Enemy;

namespace General
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField] Text enemyScoretxt;
        [SerializeField] Text enemyCaptxt;
        [SerializeField] GameObject looseMenu;
        [SerializeField] GameObject winMenu;
        [SerializeField] int enemyCap = 0;
        [SerializeField] int enemyCount = 0;
        void Awake()
        {
            instance = this;
            winMenu.SetActive(false);
            looseMenu.SetActive(false);
            EnemySpawn.Added += CountingEnemy;
            EnemyHealth.Removed += Score;
            EnemyHealth.Removed += DisCountingEnemy;
        }

        void Update()
        {

            if (enemyCap >= 10)
            {
                Loose();
            }
        }
        private void Loose()
        {
            if (looseMenu != null)
            {
                looseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        public void WinCondition()
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
        public void Score()
        {
            enemyCount++;
            enemyScoretxt.text = "Score: " + enemyCount.ToString();
            if (PlayerPrefs.GetInt("Score") <= enemyCount)
            {
                PlayerPrefs.SetInt("Score", enemyCount);
            }
        }
        public void CountingEnemy()
        {
            enemyCap++;
            enemyCaptxt.text = "Enemies left: " + enemyCap.ToString();
        }
        public void DisCountingEnemy()
        {
            enemyCap--;
            enemyCaptxt.text = "Enemies left: " + enemyCap.ToString();
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace General
{
    public class TimeController : MonoBehaviour
    {
        public static TimeController instance;

        [SerializeField] Text timer;
        [SerializeField] Text countdownText;
        [SerializeField] float timeCheck;

        private float startTime;
        private float elapsedTime;
        [SerializeField] float finishTime;
        public int countdownTime;

        TimeSpan timePlaying;
        private bool gamePlaying = false;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            gamePlaying = false;
            Time.timeScale = 1;
            StartCoroutine(CountdownToStart());
        }
        private void BeginGame()
        {
            startTime = Time.time;
            gamePlaying = true;
        }
        private void Update()
        {
            if (gamePlaying)
            {
                elapsedTime = Time.time - startTime;
                timePlaying = TimeSpan.FromSeconds(elapsedTime);

                string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss");
                timer.text = timePlayingStr;
            }
            CheckTime();
        }

        private void CheckTime()
        {
            if(elapsedTime >= finishTime)
            {
                GameManager gameManager = GetComponent<GameManager>();
                gameManager.WinCondition();
            }
        }

        private IEnumerator CountdownToStart()
        {
            while (countdownTime > 0)
            {
                countdownText.text = countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }
            BeginGame();
            countdownText.text = "GO!";
            yield return new WaitForSeconds(1f);
            countdownText.gameObject.SetActive(false);
        }
    }
}

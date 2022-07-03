using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
		private int score;
		public Flappy bird;
		public TextMeshProUGUI  scoreText;
		public TextMeshProUGUI  highScoreText;
		public GameObject gameOverPanel;
		public GameObject mainMenuPanel;
        public TextMeshProUGUI  MainMenuhighScoreText;
		public bool isGameOver;
		public bool isOnMainMenu;
        public PipeSpawner spawnPipes;
		private string highScoreKey = "hiscoreKey";

		private void Awake()
        {
        initiateMainMenu();

        }

    
    public void initiateMainMenu(){
            mainMenuPanel.SetActive(true);
            MainMenuhighScoreText.text = "Hi Score = " + LoadHighScore().ToString();
            isOnMainMenu=true;
            isGameOver=true;


    }
		public void gameStart()
		{
            mainMenuPanel.SetActive(false);
            isOnMainMenu=false;
            gameOverPanel.SetActive(false);

			isGameOver = false;
            Time.timeScale=1f;
			scoreText.gameObject.SetActive(true);

			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);

            spawnPipes.Startspawn();

			score = 0;
            scoreText.text = "Score: "+ score.ToString();
            highScoreText.text = "Hi Score : " + LoadHighScore().ToString();
            resetBirdPos();
			scoreText.gameObject.SetActive(true);
            highScoreText.gameObject.SetActive(true);
		}

		public void resetBirdPos(){
            bird.transform.position=new Vector3(0,0,0);


        }        

		public void UpdateScore()
		{
			if (isGameOver)
				return;

			score++;
			scoreText.text = "Score: "+ score.ToString();

		}

		public void MarkAsGameOver()
		{
			isGameOver = true;
			scoreText.gameObject.SetActive(false);


			SaveHighScore(score);
			highScoreText.text = "Hi Score" + LoadHighScore().ToString();
            Time.timeScale=0f;
            score = 0;
           resetBirdPos();
			gameOverPanel.SetActive(true);
            spawnPipes.stopSpawn();


            
		}


		private void SaveHighScore(int score)
		{
			if (score > LoadHighScore())
			{
				PlayerPrefs.SetInt(highScoreKey, score);
			}
		}

		public int LoadHighScore()
		{
			if (PlayerPrefs.HasKey(highScoreKey))
			{
				return PlayerPrefs.GetInt(highScoreKey);
			}
			else
			{
				return 0;
			}
		}

}

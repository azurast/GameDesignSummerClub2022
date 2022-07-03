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

		public bool isGameOver;

		private string highScoreKey = "hiscoreKey";

		private void Awake()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);


			score = 0;
            highScoreText.text = "Hi Score" + LoadHighScore().ToString();
            resetBirdPos();
			isGameOver = false;
            Time.timeScale=1f;
			scoreText.gameObject.SetActive(true);
            highScoreText.gameObject.SetActive(true);
		}



		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && isGameOver)
			{
            gameOverPanel.SetActive(false);

            score = 0;	
            scoreText.text = "Score: "+ score.ToString();
			isGameOver = false;
            Time.timeScale=1f;
			scoreText.gameObject.SetActive(true);
            }

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

            resetBirdPos();
			gameOverPanel.SetActive(true);

			SaveHighScore(score);
			highScoreText.text = "Hi Score" + LoadHighScore().ToString();
            Time.timeScale=0f;
            score = 0;

            
		}


		private void SaveHighScore(int score)
		{
			if (score > LoadHighScore())
			{
				PlayerPrefs.SetInt(highScoreKey, score);
			}
		}

		private int LoadHighScore()
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

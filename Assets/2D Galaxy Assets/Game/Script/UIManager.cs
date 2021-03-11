using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Image livesImageDisplay2;
    public GameObject tittleScreen;
    public Text scoreText;
    public Text bestText;
    public int score;
    public int score2;
    public int bestScore = 0;
    public int bestScore2 = 0;
    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager.isCoopMode == false)
        {
            bestScore = PlayerPrefs.GetInt("HighScore", 0);
            bestText.text = "Best: " + bestScore;
        }
        else if (_gameManager.isCoopMode == true)
        {
            bestScore2 = PlayerPrefs.GetInt("HighScore2", 0);
            bestText.text = "Best: " + bestScore2;
        }


    }
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];

    }

    public void UpdateLives2(int currentLives)
    {

        livesImageDisplay2.sprite = lives[currentLives];

    }

    public void UpdateScore()
    {
        if (_gameManager.isCoopMode == false)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        else if(_gameManager.isCoopMode == true)
        {
            score2++;
            scoreText.text = "Score: " + score2;
        }


    }

    public void CheckForBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("HighScore", bestScore);
            bestText.text = "Best: " + bestScore;
        }
    }

    public void CheckForBestScoreCoop()
    {
        if(score2 > bestScore2)
        {
            bestScore2 = score2;
            PlayerPrefs.SetInt("HighScore2", bestScore2);
            bestText.text = "Best: " + bestScore2;
        }

    }

    public void ShowTitleScreen()
    {
        tittleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        tittleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void ControlsSP()
    {
        SceneManager.LoadScene("Controls_SP");
    }

    public void Resume()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.ResumeGame();
    }

}

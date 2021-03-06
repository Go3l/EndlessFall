﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text ScoreGameOverText;
    public Text LastScoreGameOverText;
    public Text hScorePauseText;

    public GameObject scoreContainer;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private void Awake()
    {
        scoreContainer.SetActive(true);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOverPanel(int score)
    {
        LastScoreGameOverText.text = "Last Score: " + SaveData.GetLastScore();
        SaveData.SaveLastScore(score);

        if (score > SaveData.GetHighScore())
        {
            SaveData.SaveHighScore(score);
            ScoreGameOverText.text = "Score: " + score + " !!New Record!!";
        }
        else
        {
            ScoreGameOverText.text = "Score: " + score;
        }

        scoreContainer.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void PausePanel(bool ispaused)
    {
        pausePanel.SetActive(ispaused);
    }
}

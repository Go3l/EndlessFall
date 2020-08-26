using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public static bool isGameOver;
    [HideInInspector] public static bool isPaused;
    public UIManager uiManager;
    public FadeEffect fadeFx;

    private int score;
    private bool isLoadingLevel = false;

    private const string menuScene = "Home";
    private const string gameScene = "Game";

    private void Start()
    {
        fadeFx.Fade(true);
        isGameOver = false;
        ResetScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(true);
        }
    }

    public void IncrementScore()
    {
        score++;
        uiManager.UpdateScore(score);
    }

    private void ResetScore()
    {
        score = 0;
    }

    public void GameOver()
    {
        uiManager.GameOverPanel(score);
        isGameOver = true;
    }

    public void PlayAgain()
    {
        if (!isLoadingLevel)
        {
            StartCoroutine(LoadScene(gameScene));
        }
    }

    public void Home()
    {
        if (!isLoadingLevel)
        {
            StartCoroutine(LoadScene(menuScene));
        }
    }

    public void Pause(bool pause)
    {
        if (isGameOver || fadeFx.isFading)
            return;

        if (pause)
        {
            Time.timeScale = 0;
            uiManager.PausePanel(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            uiManager.PausePanel(false);
            isPaused = false;
        }
    }

    private IEnumerator LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        fadeFx.Fade(false);

        isLoadingLevel = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}

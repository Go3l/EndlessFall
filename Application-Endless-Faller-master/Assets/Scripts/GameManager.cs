using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string gameScene;

    public Text highScore;

    public FadeEffect fadeFx;

    private void Awake()
    {
        highScore.text = "Highscore: " + SaveData.GetHighScore();
    }

    private void Start()
    {
        fadeFx.Fade(true);
    }

    public void Play()
    {
        StartCoroutine(LoadScene(gameScene));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        fadeFx.Fade(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}

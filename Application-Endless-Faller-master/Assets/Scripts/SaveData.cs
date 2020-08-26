using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    static public void SaveScore(bool newHighScore, int score)
    {
        ScoreData _ScoreData = new ScoreData();

        if (newHighScore)
        {
            _ScoreData.highScore = score;
        }

        _ScoreData.lastScore = score;
        string scoreData = JsonUtility.ToJson(_ScoreData);
        File.WriteAllText(Application.persistentDataPath + "/ScoreData.json", scoreData);
    }

    static public int GetHighScore()
    {
        var data = File.ReadAllText(Application.persistentDataPath + "/ScoreData.json");
        var scoreData = JsonUtility.FromJson<ScoreData>(data);

        return scoreData.highScore;
    }

    static public int GetLastScore()
    {
        var data = File.ReadAllText(Application.persistentDataPath + "/ScoreData.json");
        var scoreData = JsonUtility.FromJson<ScoreData>(data);

        return scoreData.lastScore;
    }

    public class ScoreData
    {
        public int highScore = 0;
        public int lastScore;
    }
}

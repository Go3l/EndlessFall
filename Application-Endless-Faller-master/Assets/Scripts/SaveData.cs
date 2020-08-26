using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    static public void SaveHighScore(int score)
    {
        ScoreData _ScoreData = new ScoreData();

        _ScoreData.highScore = score;
        string scoreData = JsonUtility.ToJson(_ScoreData);
        File.WriteAllText(Application.persistentDataPath + "/ScoreData.json", scoreData);
    }

    static public void SaveLastScore(int score)
    {
        LastScoreData _ScoreData = new LastScoreData();

        _ScoreData.lastScore = score;
        string scoreData = JsonUtility.ToJson(_ScoreData);
        File.WriteAllText(Application.persistentDataPath + "/LastScoreData.json", scoreData);
    }

    static public int GetHighScore()
    {
        var data = File.ReadAllText(Application.persistentDataPath + "/ScoreData.json");
        var scoreData = JsonUtility.FromJson<ScoreData>(data);

        return scoreData.highScore;
    }

    static public int GetLastScore()
    {
        if (File.Exists(Application.persistentDataPath + "/LastScoreData.json"))
        {
            var data = File.ReadAllText(Application.persistentDataPath + "/LastScoreData.json");
            var scoreData = JsonUtility.FromJson<LastScoreData>(data);

            return scoreData.lastScore;
        }
        else
        {
            return 0;
        }
    }

    public class ScoreData
    {
        public int highScore = 0;
    }

    public class LastScoreData
    {
        public int lastScore;
    }

}

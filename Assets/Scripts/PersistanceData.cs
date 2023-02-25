using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistanceData : MonoBehaviour
{
    public static PersistanceData Instance;

    public string bestScorePlayerName;
    public string currentPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        GetSavedBestScore();
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;
    }

    public void SetBestScore(string playerName, int score)
    {
        bestScorePlayerName = playerName;
        bestScore = score;

        SaveBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestScorePlayerName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData saveData = new SaveData();
        saveData.bestScorePlayerName = bestScorePlayerName;
        saveData.bestScore = bestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void GetSavedBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            bestScore = saveData.bestScore;
            bestScorePlayerName = saveData.bestScorePlayerName;
        }
    }
}

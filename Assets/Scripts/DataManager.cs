using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]  // JSON 변환하려면 필요함
public class SaveData
{
    public int bestScore;
    public string bestPlayerName;
}

public class DataManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static DataManager Instance {  get; private set; }
    public int BestScore { get; private set; }
    public string BestPlayerName {  get; private set; }
    public string currentPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    // BestScore에 BestScore와 BestPlayerName을 저장하는 함수
    public void SaveBestScore(int score, string playerName)
    {
        BestScore = score;
        BestPlayerName = playerName;
    }

    public void SaveDataToJson()
    {
        SaveData data = new SaveData();
        {
            data.bestScore = BestScore;
            data.bestPlayerName = BestPlayerName;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.bestScore;
            BestPlayerName = data.bestPlayerName;
        }
    }
}

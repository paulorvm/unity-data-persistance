using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private DataHandler Data;
    private string SaveFilePath;
    private string Name;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SaveFilePath = Application.persistentDataPath + "/save.json"; ;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public string GetName()
    {
        return Name;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public string GetHighScoreName()
    {
        return Data.Name;
    }

    public void SetHighScoreName()
    {
        Data.Name = Name;
    }

    public int GetHighScore()
    {
        return Data.HighScore;
    }

    public void SetHighScore(int highScore)
    {
        Data.HighScore = highScore;
    }

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(Data);
        File.WriteAllText(SaveFilePath, jsonData);
        Debug.Log(SaveFilePath);
    }

    public void Load()
    {
        if (File.Exists(SaveFilePath))
        {
            string jsonData = File.ReadAllText(SaveFilePath);
            Data = JsonUtility.FromJson<DataHandler>(jsonData);
        }
        else
        {
            Data = new DataHandler();
        }

    }
    class DataHandler
    {
        public string Name;
        public int HighScore = 0;
    }
}

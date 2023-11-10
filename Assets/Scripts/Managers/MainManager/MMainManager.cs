using System.IO;
using UnityEngine;

public class MMainManager : MonoBehaviour
{
    public static MMainManager Instance;

    public string playerName;

    public int highScore;
    public string highPName;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadPlayerData();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string pName;
        public int score;
    }

    public void SavePLayerData()
    {
        SaveData data = new SaveData();
        data.score = highScore;
        data.pName = highPName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highPName = data.pName;
            highScore = data.score;
        }
        else
        {
            highScore = 0;
        }

    }
}

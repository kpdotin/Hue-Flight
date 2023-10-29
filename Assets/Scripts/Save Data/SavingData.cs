using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class SavingData : MonoBehaviour
{
    bool EncryptionEnabled = false;
    IDataService DataService = new JsonDataService();
    SerializableClass SerializableClass = new SerializableClass();

    private void Start()
    {
        SerilizeData();
    }
    public class Status
    {
        public int Orbs { get; set; }
        public int LevelsCompleted { get; set; }
    }
    public void SerilizeData()
    {
        int test = InGameUI.coinsCollected;

        Status incoming = new Status();
        if(!File.Exists(Application.persistentDataPath + "/playerData.json"))
        {
            using FileStream stream = File.Create(Application.persistentDataPath + "/playerData.json");
            stream.Close();
        }
        using StreamReader reader = new StreamReader(Application.persistentDataPath + "/playerData.json");
        {
            string line = reader.ReadToEnd();
            reader.Close();
            if(JsonConvert.DeserializeObject<Status>(line) == null)
            {
                incoming.LevelsCompleted = 0;
                incoming.Orbs = 0;
            }
            else
            {
                incoming = JsonConvert.DeserializeObject<Status>(line);
            }
        }
        SerializableClass.LevelsCompleted = incoming.LevelsCompleted;
        if(SerializableClass.LevelsCompleted != LevelManager.currentLevel)
        {
            SerializableClass.LevelsCompleted++;
        }
        SerializableClass.Orbs = incoming.Orbs; 
        SerializableClass.Orbs += test;
        
        if (DataService.SaveData("/playerData.json", SerializableClass, EncryptionEnabled))
        {
            Debug.Log("File Saved");
        }
    }

    public void LoadData()
    {
        try
        {
            SerializableClass data = DataService.LoadData<SerializableClass>("/playerData.json", EncryptionEnabled);
            //test.text = JsonConvert.SerializeObject(data, Formatting.Indented);
            //string testing  = JsonConvert.SerializeObject(data);
        }
        catch { Debug.LogError("Could not read File!"); }
    }

    
}

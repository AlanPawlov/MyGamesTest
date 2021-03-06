using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

[Serializable]
public class SaveData
{
    public string name;
    public int scores;
}

public class SaveLoadController
{
    #region Fields

    private static string _savePath;
    private static SaveLoadController _instance;

    #endregion

    #region Properties

    public static SaveLoadController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveLoadController();
                _savePath = $"{Application.persistentDataPath}/MySaveData.dat";
            }
            return _instance;
        }
    }

    #endregion

    #region Methods

    public SaveData[] Load()
    {
        SaveData[] loadedData = null;
        if (File.Exists(_savePath))
        {
            loadedData = JsonConvert.DeserializeObject<SaveData[]>(File.ReadAllText(_savePath));
        }
        return loadedData;
    }

    public void Save(SaveData[] data)
    {
        Debug.Log(_savePath);
        var jsonString = JsonConvert.SerializeObject(data);
        File.WriteAllText(_savePath, jsonString);
    }

    #endregion
}

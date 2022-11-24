using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    [SerializeField] private static PlayerData CurrentSaveData = new PlayerData();

    public const string SAVE_DIRECTORY = "/DataSaver";
    public const string FILE_NAME = "DataSaver.sav";


    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + SAVE_DIRECTORY;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FILE_NAME, json);

        GUIUtility.systemCopyBuffer = dir + FILE_NAME;

        return true;
    }

    public static void LoadGame()
    {
        string fullPath = Application.persistentDataPath + SAVE_DIRECTORY + FILE_NAME;
        PlayerData tempData = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save file does not exist!");
        }
        CurrentSaveData = tempData;

    }
}

[System.Serializable]
public class PlayerData
{
    public string Name { get; set; } = "Default Name";
    public int Money { get; set; }
}

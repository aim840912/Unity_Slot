using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static PlayerData CurrentSaveData = new PlayerData();

    public const string SAVE_DIRECTORY = "/DataSaver/";
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

        // GUIUtility.systemCopyBuffer = dir + FILE_NAME;

        return true;
    }

    public static PlayerData LoadGame()
    {
        string fullPath = Application.persistentDataPath + SAVE_DIRECTORY + FILE_NAME;


        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            CurrentSaveData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            SaveGame();
        }
        return CurrentSaveData;
    }
}

[System.Serializable]
public class PlayerData
{
    public int money = 1000;
}

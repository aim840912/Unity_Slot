using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static PlayerData CurrentSaveData = new PlayerData();
    public static BoardData CurrentBoardSaveData = new BoardData();

    public const string SAVE_DIRECTORY = "/DataSaver/";
    public const string FILE_NAME = "DataSaver.sav";

    public const string SLOT_SAVE_DIRECTORY = "/SlotSaver/";
    public const string SLOT_FILE_NAME = "SlotSaver.sav";

    #region Player
    public static void SavePlayerData()
    {
        var dir = Application.persistentDataPath + SAVE_DIRECTORY;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FILE_NAME, json);

        GUIUtility.systemCopyBuffer = dir + FILE_NAME;
    }

    public static PlayerData LoadPlayerData()
    {
        string fullPath = Application.persistentDataPath + SAVE_DIRECTORY + FILE_NAME;


        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            CurrentSaveData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            SavePlayerData();
        }
        return CurrentSaveData;
    }
    #endregion

    #region Board
    public static void SaveBoard()
    {
        var dir = Application.persistentDataPath + SLOT_SAVE_DIRECTORY;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(CurrentBoardSaveData, true);
        File.WriteAllText(dir + SLOT_FILE_NAME, json);

        GUIUtility.systemCopyBuffer = dir + SLOT_FILE_NAME;
    }

    public static BoardData LoadBoard()
    {
        string fullPath = Application.persistentDataPath + SLOT_SAVE_DIRECTORY + SLOT_FILE_NAME;

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            CurrentBoardSaveData = JsonUtility.FromJson<BoardData>(json);
        }
        else
        {
            SaveBoard();
        }
        return CurrentBoardSaveData;
    }
    #endregion
}

[System.Serializable]
public class PlayerData
{
    public int money = 1000;
}

[System.Serializable]
public class BoardData
{
    public int[] boardNum = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
}

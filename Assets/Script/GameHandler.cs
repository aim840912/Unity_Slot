using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler
{
    PlayerData playerData = new PlayerData();

    public void WritePlayerData(int money)
    {
        playerData.Money = money;

        string playerJson = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/saveFile.json", playerJson);
        PlayerPrefs.SetString("SaveData", playerJson);
    }

    public PlayerData ReadPlayerData()
    {
        string playerJson = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(playerJson);
        PlayerPrefs.GetString("SaveData");
        return loadedPlayerData;
    }
}

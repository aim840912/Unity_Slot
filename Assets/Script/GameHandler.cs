using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler
{

    public GameHandler()
    {
        string playerJson = File.ReadAllText(Application.dataPath + "/saveFile.json");
        if (playerJson == null)
        {
            File.Create(Application.dataPath + "/saveFile.json");
        }
    }
    PlayerData playerData = new PlayerData();

    public void WritePlayerData(int money)
    {
        playerData.Money = money;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        PlayerPrefs.SetString("SaveData", json);

    }

    public PlayerData ReadPlayerData()
    {
        string playerJson = File.ReadAllText(Application.dataPath + "/saveFile.json");

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(playerJson);
        PlayerPrefs.GetString("SaveData");
        return loadedPlayerData;


    }
}

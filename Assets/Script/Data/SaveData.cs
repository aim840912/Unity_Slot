using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    PlayerPrefs 儲存方式 尚未使用
*/
public class SaveData : MonoBehaviour
{
    void SavePlayerData(int money)
    {
        PlayerPrefs.SetInt("money", money);
    }

    void LoadPlayerData()
    {
        int money = PlayerPrefs.GetInt("money");
    }

    void SaveBoardData(int[] boardNum)
    {

        for (var i = 0; i < boardNum.Length; i++)
        {
            PlayerPrefs.SetInt("board" + i, boardNum[i]);
        }
    }


}

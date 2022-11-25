using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int[] boardNum;
    void Start()
    {
        SaveManager.LoadGame();
    }


    public void StoreBoardNum(int[] boardNum)
    {
        for (int i = 0; i < boardNum.Length; i++)
        {
            PlayerPrefs.SetInt("BoardNum" + i, boardNum[i]);
        }
    }
    public int[] GetBoardNum()
    {
        for (int i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = PlayerPrefs.GetInt("BoardNum" + i);
        }

        return boardNum;
    }
}

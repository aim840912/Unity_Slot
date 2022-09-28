using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard
{
    int[] boardNum = new int[9];

    public int[] GenerateNum(int minNum, int MaxNum)
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(minNum, MaxNum);
        }

        return boardNum;
    }

    /* Note: 機率 尚未完成*/
    // void CountProbability()
    // {
    //     for (int i = 0; i < OddsDict.dicNormal.Count; i++)
    //     {
    //         List<int> listValue = OddsDict.dicNormal.Values.ToList();
    //         foreach (int item in listValue)
    //         {
    //             sum += item;
    //         }
    //     }
    // }
}

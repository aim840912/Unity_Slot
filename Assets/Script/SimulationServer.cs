using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationServer : MonoBehaviour
{

    public static SimulationServer Instance { get; set; }

    public int[] boardNum = new int[9];

    int minRandomNum = 0;
    int maxRandomNum = 10;

    int money = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    public int[] GenerateNum() // 版面產生隨機數字，機率可在這更改
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(minRandomNum, maxRandomNum);
        }

        return boardNum;
    }

    // 計算總倍率

    CalculateMoney calculateMoney = new CalculateMoney();

    int CalculateOdds()
    {
        return calculateMoney.GetOddsTotal(boardNum);
    }


    int CalculateMoney()
    {
        money += CalculateOdds();
        return money;
    }
}

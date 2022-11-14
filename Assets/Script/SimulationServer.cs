using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 模擬後端
public class SimulationServer : MonoBehaviour
{
    public static SimulationServer Instance { get; set; }
    public int[] boardNum = new int[9];
    int maxRandomNum = 10;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public int[] GenerateNum() // 模擬伺服器產生數字
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(0, maxRandomNum);
        }
        return boardNum;
    }

    CalculateMoney calculateMoney = new CalculateMoney();

    public int CalculateOdds(int[] boardArr)
    {
        return calculateMoney.GetOddsTotal(boardArr);
    }

    public int CalculateFinalMoney(int[] boardArr, int betMoney)
    {
        return calculateMoney.GetOddsTotal(boardArr) * (betMoney / 8);
    }
}

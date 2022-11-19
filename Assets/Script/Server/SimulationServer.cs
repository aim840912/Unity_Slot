using UnityEngine;

public class SimulationServer : IServer
{
    public int[] BoardNum = new int[9];
    public int MaxRandomNum { get { return 10; } }

    public int[] GenerateNum()
    {
        for (var i = 0; i < BoardNum.Length; i++)
        {
            BoardNum[i] = Random.Range(0, MaxRandomNum);
        }
        return BoardNum;
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

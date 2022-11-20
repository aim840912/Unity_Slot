using UnityEngine;

public class SimulationServer : IServer
{
    public int[] BoardNum = new int[9];
    public const int MaxRandomNum = 10;

    public int[] GenerateNum()
    {
        for (var i = 0; i < BoardNum.Length; i++)
        {
            BoardNum[i] = Random.Range(0, MaxRandomNum);
        }
        return BoardNum;
    }

    CalculateMoney calculateMoney = new CalculateMoney();

    public int CalculateOdds()
    {
        return calculateMoney.GetOddsTotal(BoardNum);// so bad,多此一舉 改成 BoardNum
    }

    public int CalculateFinalMoney(int betMoney)
    {
        return CalculateOdds() * (betMoney / 8);
    }
}

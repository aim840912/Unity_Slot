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
        return calculateMoney.GetOddsTotal(boardArr);// so bad,多此一舉 改成 BoardNum
    }

    public int CalculateFinalMoney(int[] boardArr, int betMoney)
    {
        return CalculateOdds(boardArr) * (betMoney / 8);
    }
}

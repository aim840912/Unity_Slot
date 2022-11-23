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
    GameHandler gameHandler = new GameHandler();
    CalculateMoney calculateMoney = new CalculateMoney();

    public int GetOdds()
    {
        return calculateMoney.GetOddsTotal(BoardNum);
    }

    public int GetFinalMoney(int betMoney)
    {
        int money = gameHandler.ReadPlayerData().Money;
        money += GetOdds() * (betMoney / 8);
        gameHandler.WritePlayerData(money);
        return money;
    }


}

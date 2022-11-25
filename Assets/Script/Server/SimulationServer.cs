using UnityEngine;

public class SimulationServer : IServer
{
    public int[] BoardNum = new int[9];
    public const int MAX_RANDOM_NUM = 10;

    public int[] GenerateNum()
    {
        for (var i = 0; i < BoardNum.Length; i++)
        {
            BoardNum[i] = Random.Range(0, MAX_RANDOM_NUM);
        }
        return BoardNum;
    }

    CalculateMoney calculateMoney = new CalculateMoney();


    public int GetOdds()
    {
        return calculateMoney.GetOddsTotal(BoardNum);
    }

    public int GetFinalMoney(int betMoney)
    {
        int money = SaveManager.CurrentSaveData.money;
        money += -betMoney + GetOdds() * (betMoney / 8);
        SaveManager.CurrentSaveData.money = money;
        SaveManager.SaveGame();
        return money;
    }
}

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

    GameManager gameManager = new GameManager();
    public int GetOdds()
    {
        gameManager.StoreBoardNum(BoardNum);
        return calculateMoney.GetOddsTotal(BoardNum);
    }

    public int GetFinalMoney(int betMoney)
    {
        int money = SaveManager.CurrentSaveData.Money;
        money += GetOdds() * (betMoney / 8);
        SaveManager.CurrentSaveData.Money = money;
        SaveManager.SaveGame();
        return money;
    }


}

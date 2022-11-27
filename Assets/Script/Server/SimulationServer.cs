using UnityEngine;
/*
    模擬後端
*/
public class SimulationServer : IServer
{
    public int[] BoardNum = new int[9];
    public const int MAX_RANDOM_NUM = 10;
    CalculateMoney calculateMoney = new CalculateMoney();

    public int[] GenerateNum()
    {
        for (var i = 0; i < BoardNum.Length; i++)
        {
            BoardNum[i] = Random.Range(0, MAX_RANDOM_NUM);
        }
        return BoardNum;
    }

    public int GetFinalMoney(int betMoney, out int odds)
    {
        odds = calculateMoney.GetOdds(BoardNum);

        int money = GetData();

        money += odds * (betMoney / 8) - betMoney;
        SaveData(money);
        return money;
    }

    int GetData()
    {
        return SaveManager.CurrentSaveData.money;
    }

    void SaveData(int money)
    {
        SaveManager.CurrentSaveData.money = money;
        SaveManager.SaveGame();
    }
}

using UnityEngine;
/*
    模擬後端 產生盤面 金錢計算 前端自取
*/
public class SimulationServer : Server
{
    int[] _boardNum = new int[9];
    public const int MAX_RANDOM_NUM = 10;
    CalculateMoney calculateMoney = new CalculateMoney();

    public override int[] GenerateNum()
    {
        for (var i = 0; i < _boardNum.Length; i++)
        {
            _boardNum[i] = Random.Range(0, MAX_RANDOM_NUM);
        }
        return _boardNum;
    }

    public override int GetFinalMoney(int betMoney, out int win)
    {
        int odds = calculateMoney.GetOdds(_boardNum);

        int money = GetData();
        int reduceMoney = betMoney * 8;
        int winMoney = odds * betMoney - reduceMoney;
        win = winMoney;
        money += winMoney;
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
        SaveManager.SavePlayerData();
    }
}

using UnityEngine;
/*
    模擬後端
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

    public override int GetFinalMoney(int betMoney, out int odds)
    {
        odds = calculateMoney.GetOdds(_boardNum);

        int money = GetData();

        money += odds * betMoney - betMoney * 8;
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

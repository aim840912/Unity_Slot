using UnityEngine;
/*
    模擬後端 產生盤面 金錢計算
*/
public class SimulationServer : Server
{
    int[] _slotBoardCount = new int[9];
    const int MAX_RANDOM_NUM = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();
    public override int[] GenerateNum()
    {
        for (var i = 0; i < _slotBoardCount.Length; i++)
        {
            _slotBoardCount[i] = Random.Range(0, MAX_RANDOM_NUM);
        }
        return _slotBoardCount;
    }

    public override int GetFinalMoney(int betMoney, out int win)
    {
        int multiple = _calcMultiple.GetMultiple(_slotBoardCount);
        Debug.Log($"{multiple}");
        int money = GetData();
        int reduceMoney = betMoney * 8;
        int winMoney = multiple * betMoney - reduceMoney;
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

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

    public override int GetFinalMoney(int betMoney, out int winMoney)
    {
        int multiple = _calcMultiple.GetMultiple(_slotBoardCount);
        Debug.Log($"{multiple}");

        int playerMoney = GetData();

        winMoney = multiple * betMoney - 8 * betMoney;
        playerMoney += winMoney;

        SaveData(playerMoney);
        return playerMoney;
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

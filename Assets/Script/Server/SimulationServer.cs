using UnityEngine;
/*
    模擬後端 產生盤面 金錢計算
*/
public class SimulationServer : Server
{
    int[] _gameBoard = new int[9];
    const int MIN_NUMBER = 0;
    const int MAX_NUMBER = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();
    public override int[] GenerateGameBoard()
    {
        for (var i = 0; i < _gameBoard.Length; i++)
        {
            _gameBoard[i] = Random.Range(MIN_NUMBER, MAX_NUMBER);
        }
        return _gameBoard;
    }

    public override int GetPlayerFinalMoney(int betMoney)
    {
        int playerMoney = GetData();

        playerMoney += CalcBet(betMoney);

        SaveData(playerMoney);
        return playerMoney;
    }

    int CalcBet(int betMoney)
    {
        int multiple = _calcMultiple.GetMultiple(_gameBoard);
        Debug.Log($"{multiple}");

        int bet = multiple * betMoney - 8 * betMoney;
        return bet;
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

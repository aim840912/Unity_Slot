using UnityEngine;
/*
    產生盤面 金錢計算
*/
public class SimulationServer
{
    int[] _gameBoard = new int[9];
    const int MIN_NUMBER = 0;
    const int MAX_NUMBER = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();

    public int WinMoney { get; set; }

    public int[] GenerateGameBoardAndSave()
    {
        for (var i = 0; i < _gameBoard.Length; i++)
        {
            _gameBoard[i] = Random.Range(MIN_NUMBER, MAX_NUMBER);
        }

        SaveBoardNum(_gameBoard);

        return _gameBoard;
    }

    public void CalcWinMoneyAndSave(int inputValue)
    {
        int betMoney = inputValue;
        WinMoney = GetMultiple() * betMoney - 8 * betMoney;

        CalcPlayerMoneyAndSave();
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiple(_gameBoard);
        Debug.Log($"{multiple}");

        return multiple;
    }

    void CalcPlayerMoneyAndSave()
    {
        int playerMoney = GetPlayerMoneyFromData();

        playerMoney += WinMoney;

        SavePlayerMoneyToData(playerMoney);
    }

    public int GetPlayerMoneyFromData()
    {
        return SaveManager.CurrentSaveData.money;
    }

    void SavePlayerMoneyToData(int money)
    {
        SaveManager.CurrentSaveData.money = money;
        SaveManager.SavePlayerData();
    }

    void SaveBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

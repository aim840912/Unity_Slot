using UnityEngine;
/*
    產生盤面 金錢計算 儲存玩家資訊
*/
public class SimulationServer
{
    public int WinMoney { get; private set; }
    int[] _gameBoard = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    readonly int _minNumber = 0;
    readonly int _maxNumber = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();

    public void ServerProcess(int inputValue)
    {
        GenerateGameBoardAndSave();
        CalcMoneyAndSave(inputValue);
    }

    void GenerateGameBoardAndSave()
    {
        for (var i = 0; i < _gameBoard.Length; i++)
        {
            _gameBoard[i] = Random.Range(_minNumber, _maxNumber);
        }

        SaveBoardNum(_gameBoard);
    }

    public int[] GetServerBoardNum()
    {
        return _gameBoard;
    }

    void CalcMoneyAndSave(int currentBet)
    {
        WinMoney = GetMultiple() * currentBet - 8 * currentBet;

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

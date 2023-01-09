using UnityEngine;
/*
    產生盤面 金錢計算 儲存玩家資訊
*/
public class SimulationServer
{
    public int WinMoney { get; private set; }

    private int _playerMoney;
    public int PlayerMoney
    {
        get
        {
            return SaveManager.LoadPlayerData().money;
        }
    }
    int[] _gameBoard = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    readonly int _minNumber = 0;
    readonly int _maxNumber = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();

    public void ServerProcess(int inputValue)
    {
        GenerateGameBoard();
        SaveGameBoard(_gameBoard);
        CalcMoney(inputValue);
        SavePlayerMoneyToData(_playerMoney);
    }

    void GenerateGameBoard()
    {
        for (var i = 0; i < _gameBoard.Length; i++)
        {
            _gameBoard[i] = Random.Range(_minNumber, _maxNumber);
        }
    }

    void SaveGameBoard(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }

    void CalcMoney(int currentBet)
    {
        WinMoney = GetMultiple() * currentBet - 8 * currentBet;

        _playerMoney = PlayerMoney;

        _playerMoney += WinMoney;
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiple(_gameBoard);
        Debug.Log($"{multiple}");

        return multiple;
    }

    void SavePlayerMoneyToData(int money)
    {
        SaveManager.CurrentSaveData.money = money;
        SaveManager.SavePlayerData();
    }

    public int[] GetServerBoardNum()
    {
        return _gameBoard;
    }

    public int[] LoadBoardNum()
    {
        return SaveManager.LoadBoard().boardNum;
    }
}

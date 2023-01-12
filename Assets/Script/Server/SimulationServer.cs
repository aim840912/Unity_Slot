using UnityEngine;
/*
    產生盤面 金錢計算 儲存玩家資訊
*/
public class SimulationServer
{
    private SimulationServer() { }
    private static SimulationServer _instance = new SimulationServer();
    public static SimulationServer getInstance()
    {
        if (_instance == null)
        {
            _instance = new SimulationServer();
        }
        return _instance;
    }
    public int WinMoney { get; private set; }
    public int PlayerMoney
    {
        get
        {
            return SimulationDataBase.getInstance().LoadPlayerData().money;
        }
    }
    int _currentMoney;
    int[] _gameBoard = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    readonly int _minNumber = 0;
    readonly int _maxNumber = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();

    public void ServerProcess(int inputValue)
    {
        GenerateGameBoard();
        SaveGameBoard(_gameBoard);
        CalcMoney(inputValue);
        SavePlayerMoneyToData(_currentMoney);
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
        SimulationDataBase.getInstance().CurrentBoardSaveData.boardNum = boardNum;
        SimulationDataBase.getInstance().SaveBoard();
    }

    void CalcMoney(int currentBet)
    {
        WinMoney = GetMultiple() * currentBet - 8 * currentBet;

        _currentMoney = PlayerMoney + WinMoney;
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiple(_gameBoard);
        Debug.Log($"{multiple}");

        return multiple;
    }

    void SavePlayerMoneyToData(int money)
    {
        SimulationDataBase.getInstance().CurrentSaveData.money = money;
        SimulationDataBase.getInstance().SavePlayerData();
    }

    public int[] GetServerBoardNum()
    {
        return _gameBoard;
    }

    public int[] LoadBoardNum()
    {
        return SimulationDataBase.getInstance().LoadBoard().boardNum;
    }
}

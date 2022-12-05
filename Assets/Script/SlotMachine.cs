using System.Collections;
using UnityEngine;
using TMPro;

public class SlotMachine : MonoBehaviour, ISpin
{
    public int[] BoardNum { get; set; }

    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    int BetMoney { get { return GetInputValue(); } }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        LoadBoardNum(BoardNum);
        SaveManager.LoadPlayerData();
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money.ToString()}";
    }

    public void SpinEvent(bool _isStop)
    {
        _inputBet.interactable = _isStop;

        if (_isStop)
        {
            GetServerData();
        }
    }

    void GetServerData()
    {
        Server server = new SimulationServer();
        BoardNum = server.GenerateNum();

        StoreBoardNum(BoardNum);

        int win = 0;
        int finalMoney = server.GetFinalMoney(BetMoney, out win);

        _playerMoneyText.text = $"{finalMoney.ToString()}";
        _winMoneyText.text = $"{win.ToString()}";
    }


    int GetInputValue()
    {
        if (_inputBet.text == "")
            return 0;

        int betMoney = int.Parse(_inputBet.text);

        if (betMoney * 8 > SaveManager.CurrentSaveData.money)
        {
            return 0;
        }
        return betMoney < 0 ? 0 : betMoney;
    }

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }

    void LoadBoardNum(int[] boardNum)
    {
        BoardNum = SaveManager.LoadBoard().boardNum;
    }
}

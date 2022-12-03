using System.Collections;
using UnityEngine;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public int[] BoardNum { get; set; }
    [SerializeField] LineHandler _lineHandler;

    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;
    bool _isSpin;
    int BetMoney { get { return GetInputValue(); } }
    void Awake()
    {
        Init();
    }

    void Init()
    {
        LoadBoardNum(BoardNum);
        SaveManager.LoadPlayerData();
        _playerMoneyText.text = $"player : {SaveManager.LoadPlayerData().money.ToString()}";

        Btn.OnClicked += SpinEvent;
    }

    void SpinEvent()
    {
        if (!_isSpin)
        {
            StartSpin();
        }
        else
        {
            StopSpin();
        }
        _isSpin = !_isSpin;
    }
    public void StartSpin()
    {
        StartCoroutine(IsLineShowing(false));
        _inputBet.interactable = false;
    }

    public void StopSpin()
    {
        GetServerData();
        StartCoroutine(IsLineShowing(true));
        _inputBet.interactable = true;
    }

    IEnumerator IsLineShowing(bool isLineEffectAppear)
    {
        if (isLineEffectAppear)
        {
            yield return new WaitForSeconds(2f);
            _lineHandler.AfterSpin(BoardNum);
        }
        else
        {
            _lineHandler.BeforeSpin();
        }
    }

    void GetServerData()
    {
        Server server = new SimulationServer();
        BoardNum = server.GenerateNum();

        StoreBoardNum(BoardNum);

        int oddsTotal = 0;
        int finalMoney = server.GetFinalMoney(BetMoney, out oddsTotal);

        _playerMoneyText.text = $"player : {finalMoney.ToString()}";
        _winMoneyText.text = $"oddsTotal : {oddsTotal.ToString()}";
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

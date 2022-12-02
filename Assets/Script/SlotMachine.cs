using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public int[] BoardNum { get; set; }

    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    [Header("Data")]
    [SerializeField] Data _imageData;

    // [SerializeField] SpinHandler[] _spinObjs;
    [SerializeField] SpinHandlerTest _spinObj;
    [SerializeField] LineHandler _lineHandler;

    int BetMoney { get { return GetInputValue(); } }
    void Awake()
    {
        Init();
    }

    void Init()
    {
        LoadBoardNum(BoardNum);
        SaveManager.LoadGame();
        _playerMoneyText.text = $"player : {SaveManager.LoadGame().money.ToString()}";

        SpinEvent(true);
    }
    void SpinEvent(bool isSpin)
    {
        if (isSpin)
        {
            Btn.OnClicked += StartSpin;
            Btn.OnClicked -= StopSpin;
        }
        else
        {
            Btn.OnClicked -= StartSpin;
            Btn.OnClicked += StopSpin;
        }

    }
    public void StartSpin()
    {
        SpinEvent(false);
        StartCoroutine(IsLineShowing(false));
        _inputBet.interactable = false;
        // for (int i = 0; i < _spinObjs.Length; i++)
        // {
        //     _spinObjs[i].SetType(SpinHandler.SpinType.motionless, null);
        // }
        _spinObj.StartSpin();
    }

    public void StopSpin()
    {
        SpinEvent(true);
        GetServerData();
        // for (int i = 0; i < _spinObjs.Length; i++)
        // {
        //     _spinObjs[i].SetType(SpinHandler.SpinType.Spinning, SetNumToImg);
        // }
        _spinObj.StopSpin();
        StartCoroutine(IsLineShowing(true));
        _inputBet.interactable = true;
    }

    void SetNumToImg()
    {
        // for (var i = 0; i < _spinObjs.Length; i++)
        // {
        //     _spinObjs[i].transform.GetChild(0).GetComponent<Image>().sprite = _imageData.RollingImage[BoardNum[i]];
        // }
        Debug.Log("cool");
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
        SetNumToImg();
    }
}

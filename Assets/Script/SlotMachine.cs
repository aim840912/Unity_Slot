using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] _rollingImageGroup = new Image[9];
    public int[] BoardNum { get; set; }

    [Header("UI")]
    [SerializeField] Btn _setupBtn;
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    [Header("Data")]
    [SerializeField] Data _imageData;

    bool _isSpin = false;

    [SerializeField] SpinHandler[] _spinObjs;

    [SerializeField] LineEffect[] _lineObjs;

    int BetMoney { get { return GetInputValue(); } }
    private void Awake()
    {
        LoadBoardNum(BoardNum);
        SaveManager.LoadGame();
        _playerMoneyText.text = "player : " + SaveManager.LoadGame().money.ToString();
    }
    public void SetupBtn()
    {
        _isSpin = !_isSpin;
        _setupBtn.SetupButton();

        if (_isSpin)
        {
            StartSpin();
        }
        else
        {
            StopSpin();
        }
    }

    public void StartSpin()
    {
        StartCoroutine(SetupLineEffect(false));
        for (int i = 0; i < _spinObjs.Length; i++)
        {
            _spinObjs[i].SetType(SpinHandler.SpinType.motionless, null);
        }
    }

    public void StopSpin()
    {
        SlotProcessCoro();
        for (int i = 0; i < _spinObjs.Length; i++)
        {
            _spinObjs[i].SetType(SpinHandler.SpinType.Spinning, SetNumToImg);
        }
        StartCoroutine(SetupLineEffect(true));
    }

    void SetNumToImg()
    {
        for (var i = 0; i < _rollingImageGroup.Length; i++)
        {
            _rollingImageGroup[i].sprite = _imageData.RollingImage[BoardNum[i]];
        }
    }

    IEnumerator SetupLineEffect(bool isLineEffectAppear)
    {
        if (isLineEffectAppear)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < _lineObjs.Length; i++)
            {
                _lineObjs[i].AfterSpin();
            }
        }
        else
        {
            for (int i = 0; i < _lineObjs.Length; i++)
            {
                _lineObjs[i].BeforeSpin();
            }
        }
    }

    void SlotProcessCoro()
    {
        IServer server = new SimulationServer();
        BoardNum = server.GenerateNum();
        StoreBoardNum(BoardNum);
        int oddsTotal = server.GetOdds();

        _playerMoneyText.text = "player : " + server.GetFinalMoney(BetMoney).ToString();
        _winMoneyText.text = "win : " + server.GetOdds().ToString();

        Debug.Log(oddsTotal);
    }

    int GetInputValue()
    {
        if (_inputBet.text == "")
            return 0;

        return int.Parse(_inputBet.text) < 0 ? 0 : int.Parse(_inputBet.text);
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

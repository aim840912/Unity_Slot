using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] _rollingImageGroup = new Image[9];
    public int[] BoardNum { get; set; }
    [SerializeField] GameObject _spinObj;
    [SerializeField] GameObject _lineObj;

    [Header("UI")]
    [SerializeField] Btn _setupBtn;
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;


    bool _isSpin = false;

    SetSpin[] _spinObjs;

    IEffect[] _lineObjs;

    int BetMoney
    {
        get
        {
            return GetInputValue();
        }

    }

    void Start()
    {
        SetGroup();
    }


    void SetGroup()
    {
        _lineObjs = _lineObj.GetComponentsInChildren<IEffect>();
        _spinObjs = _spinObj.GetComponentsInChildren<SetSpin>();
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
        foreach (SetSpin item in _spinObjs)
        {
            item.SetType(SetSpin.SpinType.motionless, null);
        }
    }

    public void StopSpin()
    {
        SlotProcessCoro();

        foreach (SetSpin item in _spinObjs)
        {
            item.SetType(SetSpin.SpinType.Spinning, SetNumToImg);
        }
        StartCoroutine(SetupLineEffect(true));
    }

    void SetNumToImg()
    {
        for (var i = 0; i < _rollingImageGroup.Length; i++)
        {
            _rollingImageGroup[i].sprite = DictNumToImg.numToImg[BoardNum[i]];
        }
    }

    IEnumerator SetupLineEffect(bool isLineEffectAppear)
    {
        if (isLineEffectAppear)
        {
            yield return new WaitForSeconds(2f);
            foreach (var item in _lineObjs)
            {
                item.AfterSpin();
            }
        }
        else
        {
            foreach (var item in _lineObjs)
            {
                item.BeforeSpin();
            }
        }
    }

    void SlotProcessCoro()
    {
        IServer server = new SimulationServer();
        BoardNum = server.GenerateNum();

        int oddsTotal = server.CalculateOdds();

        _winMoneyText.text = server.CalculateFinalMoney(BetMoney).ToString();

        Debug.Log(oddsTotal);
    }

    int GetInputValue()
    {
        if (_inputBet.text == "")
            return 0;

        return int.Parse(_inputBet.text) < 0 ? 0 : int.Parse(_inputBet.text);
    }
}

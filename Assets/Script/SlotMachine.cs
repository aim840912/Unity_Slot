using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{

    [SerializeField] Image[] _rollingImageGroup = new Image[9];
    public int[] BoardNum { get; set; }
    [SerializeField] GameObject _spinObj;

    [Header("UI")]
    [SerializeField] Btn _setupBtn;

    bool _isSpin = false;

    SetSpin[] _spinObjs;

    IEffect[] _lineObjs;
    [SerializeField] GameObject _lineObj;
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
        StartCoroutine(SlotProcessCoro());

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

    IEnumerator SlotProcessCoro()
    {
        IServer server = new SimulationServer();
        BoardNum = server.GenerateNum();

        int oddsTotal = server.CalculateOdds(BoardNum);

        Debug.Log(oddsTotal);

        yield return new WaitForSeconds(1f);

    }
}

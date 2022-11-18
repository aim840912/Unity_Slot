using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{

    [SerializeField] Image[] _board = new Image[9];
    [SerializeField] public int[] BoardNum { get; set; }
    [SerializeField] GameObject spinObj;

    [Header("UI")]
    [SerializeField] Btn setupBtn;

    bool isSpin = false;

    DoTweenTest[] DoTweenTestGroup;

    IEffect[] temp;
    [SerializeField] GameObject effectObj;
    void Start()
    {
        temp = effectObj.GetComponentsInChildren<IEffect>();
        DoTweenTestGroup = spinObj.GetComponentsInChildren<DoTweenTest>();
    }

    public void SetupBtn()
    {
        isSpin = !isSpin;
        setupBtn.SetupButton();

        if (isSpin)
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
        foreach (var item in DoTweenTestGroup)
        {
            item.GetComponent<DoTweenTest>().SetType(DoTweenTest.SpinType.motionless, null);
        }
    }

    public void StopSpin()
    {
        StartCoroutine(SlotProcessCoro());

        foreach (var item in DoTweenTestGroup)
        {
            item.GetComponent<DoTweenTest>().SetType(DoTweenTest.SpinType.Spinning, SetNumToImg);
        }
        StartCoroutine(SetupLineEffect(true));
    }

    void SetNumToImg()
    {
        for (var i = 0; i < _board.Length; i++)
        {
            _board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[BoardNum[i]];
        }
    }

    IEnumerator SetupLineEffect(bool isLineEffectAppear)
    {
        if (isLineEffectAppear)
        {
            yield return new WaitForSeconds(2f);
            foreach (var item in temp)
            {
                item.AfterSpin();
            }
        }
        else
        {
            foreach (var item in temp)
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

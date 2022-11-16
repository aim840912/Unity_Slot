using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DotweenSlotMachine : MonoBehaviour
{

    [SerializeField] Image[] board = new Image[9];
    [SerializeField] public int[] boardNum = new int[9];
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
        Debug.Log("in setupBtn");
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
            item.GetComponent<DoTweenTest>().SpinTypeSwitch(DoTweenTest.SpinType.motionless, null);
        }
    }

    public void StopSpin()
    {

        StartCoroutine(SlotProcessCoro());

        foreach (var item in DoTweenTestGroup)
        {
            item.GetComponent<DoTweenTest>().SpinTypeSwitch(DoTweenTest.SpinType.Spinning, NumToImg);
        }


        StartCoroutine(SetupLineEffect(true));

    }

    void NumToImg()
    {
        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
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
        boardNum = server.GenerateNum();

        int oddsTotal = server.CalculateOdds(boardNum);

        Debug.Log(oddsTotal);

        yield return new WaitForSeconds(1f);

    }
}

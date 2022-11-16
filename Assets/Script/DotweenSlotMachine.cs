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


    void Start()
    {
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
        Debug.Log("in start spin");
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

    }

    void NumToImg()
    {
        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }
    }

    IEnumerator SlotProcessCoro()
    {
        yield return new WaitForSeconds(0.5f);

        IServer server = new SimulationServer();
        boardNum = server.GenerateNum();

        int oddsTotal = server.CalculateOdds(boardNum);

        Debug.Log(oddsTotal);

    }
}

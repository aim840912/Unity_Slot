using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];
    [SerializeField] Button rotateBtn;
    [SerializeField] Button stopBtn;
    [SerializeField] GameObject EffectObj;
    [SerializeField] GameObject SpinObj;
    Spin[] spinGroup;

    void Start()
    {
        spinGroup = SpinObj.GetComponentsInChildren<Spin>();
    }
    // void GeneralBoard()
    // {
    //     for (var i = 0; i < board.Length; i++)
    //     {
    //         board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
    //     }
    // }

    void Spinning()
    {
        rotateBtn.enabled = false;
        stopBtn.enabled = true;
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", true);
        }
    }

    void SpinOver()
    {
        rotateBtn.enabled = true;
        stopBtn.enabled = false;
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", false);
        }

        for (var i = 0; i < spinGroup.Length; i++)
        {
            spinGroup[i].GetComponentInChildren<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }

    }

    IEnumerator GetServerNum()
    {

        IEffect[] temp = EffectObj.GetComponentsInChildren<IEffect>();

        foreach (var item in temp)
        {
            item.BeforeSpin();
        }

        SimulationServer.Instance.GenerateNum();
        boardNum = SimulationServer.Instance.boardNum;

        // GeneralBoard();

        rotateBtn.interactable = false;

        yield return new WaitForSeconds(0.5f);

        foreach (var item in temp)
        {
            item.AfterSpin();
        }

        int oddsTotal = SimulationServer.Instance.CalculateOdds(boardNum);

        Debug.Log(oddsTotal);

        yield return new WaitForSeconds(0.5f);
        rotateBtn.interactable = true;
    }

    public void Spin()
    {
        StartCoroutine(GetServerNum());
    }
}

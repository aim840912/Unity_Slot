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
    IEffect[] temp;
    void Start()
    {
        spinGroup = SpinObj.GetComponentsInChildren<Spin>();
        temp = EffectObj.GetComponentsInChildren<IEffect>();
    }
    // void GeneralBoard()
    // {
    //     for (var i = 0; i < board.Length; i++)
    //     {
    //         board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
    //     }
    // }

    public void Spinning()
    {
        rotateBtn.gameObject.SetActive(false);
        stopBtn.gameObject.SetActive(true);
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", true);
        }
        foreach (var item in temp)
        {
            item.BeforeSpin();
        }
    }

    public void SpinOver()
    {
        StartCoroutine(GetServerNum());
        StartCoroutine(SpinOverOrder());
    }

    IEnumerator SpinOverOrder()
    {

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", false);
        }
        yield return new WaitForSeconds(2);

        foreach (var item in temp)
        {
            item.AfterSpin();
        }
        rotateBtn.gameObject.SetActive(true);
        stopBtn.gameObject.SetActive(false);


    }

    IEnumerator GetServerNum()
    {
        SimulationServer.Instance.GenerateNum();
        boardNum = SimulationServer.Instance.boardNum;

        yield return new WaitForSeconds(0.1f);
        int oddsTotal = SimulationServer.Instance.CalculateOdds(boardNum);
        Debug.Log(oddsTotal);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];
    [SerializeField] Button rotateBtn;
    CalculateMoney calculateMoney = new CalculateMoney();

    void GeneralBoard()
    {

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }
    }

    IEnumerator GetServerNum()
    {
        SimulationServer.Instance.GenerateNum();
        boardNum = SimulationServer.Instance.boardNum;

        GeneralBoard();
        rotateBtn.interactable = false;
        GameManager.Instance.spinBool = true;

        yield return new WaitForSeconds(0.5f);

        int oddsTotal = calculateMoney.GetOddsTotal(boardNum);
        GameManager.Instance.spinBool = false;
        Debug.Log(oddsTotal);

        yield return new WaitForSeconds(0.5f);
        rotateBtn.interactable = true;
    }

    public void Spin()
    {
        StartCoroutine(GetServerNum());
    }
}

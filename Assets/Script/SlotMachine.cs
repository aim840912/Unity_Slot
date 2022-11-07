using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];

    [SerializeField] Button rotateBtn;

    public delegate void returnMoney();

    GenerateBoard generateBoard = new GenerateBoard();
    CalculateMoney calculateMoney = new CalculateMoney();



    void GeneralBoard()
    {
        boardNum = GameManager.Instance.GeneralBoard();

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }
    }

    public void Spin()
    {
        StartCoroutine(SpinAndStopAndCal());
    }

    IEnumerator SpinAndStopAndCal()
    {
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
}

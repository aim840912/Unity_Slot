using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];

    [Range(0, 9)][SerializeField] int minRandomNum = 0;
    [Range(0, 10)][SerializeField] int maxRandomNum = 10;

    [SerializeField] Button rotateBtn;

    public delegate void returnMoney();

    GenerateBoard generateBoard = new GenerateBoard();
    CalculateMoney calculateMoney = new CalculateMoney();



    void GeneralBoard()
    {
        boardNum = generateBoard.GenerateNum(minRandomNum, maxRandomNum);

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
        int oddsTotal = calculateMoney.GetOddsTotal(boardNum);

        Debug.Log(oddsTotal);
        yield return new WaitForSeconds(0.5f);
        rotateBtn.interactable = true;
    }
}

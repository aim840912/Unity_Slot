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

    CalculateMoney calculateMoney = new CalculateMoney();
    GenerateBoard generateBoard = new GenerateBoard();

    void BoardRandomNumber()
    {
        boardNum = generateBoard.GenerateNum(minRandomNum, maxRandomNum);

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = NumToImg(boardNum[i]);
        }
    }

    public void Spin()
    {
        StartCoroutine(SpinAndStopAndCal());
    }

    IEnumerator SpinAndStopAndCal()
    {
        BoardRandomNumber();
        rotateBtn.interactable = false;
        yield return new WaitForSeconds(0.5f);
        rotateBtn.interactable = true;
        int oddsTotal = calculateMoney.GetOddsTotal(boardNum);
        Debug.Log(oddsTotal);
    }

    Sprite NumToImg(int num)
    {
        switch (num)
        {
            case 0:
                return Resources.Load<Sprite>("Art/gura");
            case 1:
                return Resources.Load<Sprite>("Art/ame");
            case 2:
                return Resources.Load<Sprite>("Art/ina");
            case 3:
                return Resources.Load<Sprite>("Art/kronii");
            case 4:
                return Resources.Load<Sprite>("Art/mumei");
            case 5:
                return Resources.Load<Sprite>("Art/sana");
            case 6:
                return Resources.Load<Sprite>("Art/bae");
            case 7:
                return Resources.Load<Sprite>("Art/fauna");
            case 8:
                return Resources.Load<Sprite>("Art/irys");
            case 9:
                return Resources.Load<Sprite>("Art/hololive");
            default:
                return null;
        }
    }

}

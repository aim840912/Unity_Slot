using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];
    [SerializeField] int maxRandomNum = 12;

    CalculateMoney calculateMoney = new CalculateMoney();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BoardNumValue();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int q = calculateMoney.GetOddsTotal(boardNum);
            Debug.Log(q);
        }

    }
    void BoardNumValue()
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(0, maxRandomNum);
        }

        ShowBoardNum();

    }


    void ShowBoardNum()
    {

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponentInChildren<TextMeshProUGUI>().text = boardNum[i].ToString();
        }
    }
}

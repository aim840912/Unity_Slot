using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeEffect : MonoBehaviour
{
    [SerializeField] int[] effectInt = new int[3];

    JudgeArray judgeArray = new JudgeArray();

    bool showLine = false;

    private void Update()
    {
        if (GameManager.Instance.spinBool == false)
        {
            if (showLine == true)
            {
                this.GetComponent<Image>().enabled = JudgeRole(
           SimulationServer.Instance.boardNum[effectInt[0]],
           SimulationServer.Instance.boardNum[effectInt[1]],
           SimulationServer.Instance.boardNum[effectInt[2]]);
                showLine = false;
            }
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
            showLine = true;
        }

    }

    private bool JudgeRole(params int[] a)
    {

        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            judgeArray.CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }

        if (a[0] == 9)
        {
            return true;
        }
        else if (a[0] == a[1] && a[0] == a[2])
        {
            return true;
        }
        else if (anyBar == 3 || anySeven == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

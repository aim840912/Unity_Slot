using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeEffect : MonoBehaviour
{
    [SerializeField] int[] effectInt = new int[3];

    JudgeArray judgeArray = new JudgeArray();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Image>().enabled = JudgeRole(
           GameManager.Instance.boardNum[effectInt[0]],
           GameManager.Instance.boardNum[effectInt[1]],
           GameManager.Instance.boardNum[effectInt[2]]);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffect : MonoBehaviour
{
    [SerializeField] bool[] effectBool;
    [SerializeField] GameObject[] effectObj;

    public void GeneralEffect(int[] boardArr)
    {
        for (var i = 0; i < GetJudgeLine(boardArr).Length; i++)
        {
            effectBool[i] = JudgeRole(GetJudgeLine(boardArr)[i]);
        }
    }

    private bool JudgeRole(params int[] a)
    {
        if (a[0] == a[1] && a[0] == a[2])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int[][] GetJudgeLine(int[] boardArr)
    {
        int[][] eachLine =  {
         new int[] { boardArr[0], boardArr[1], boardArr[2] },
         new int[] { boardArr[3], boardArr[4], boardArr[5] },
         new int[] { boardArr[6], boardArr[7], boardArr[8] },
         new int[] { boardArr[0], boardArr[3], boardArr[6] },
         new int[] { boardArr[1], boardArr[4], boardArr[7] },
         new int[] { boardArr[2], boardArr[5], boardArr[8] },
         new int[] { boardArr[0], boardArr[4], boardArr[8] },
         new int[] { boardArr[6], boardArr[4], boardArr[2] },
         };

        return eachLine;
    }
}

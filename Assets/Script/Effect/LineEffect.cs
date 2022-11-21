using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEffect : MonoBehaviour
{
    [SerializeField] int[] effectInt = new int[3];

    JudgeArray judgeArray = new JudgeArray();

    public SlotMachine slotMachine;
    public void AfterSpin()
    {
        this.GetComponent<Image>().enabled = JudgeRole(
   (Odds)slotMachine.BoardNum[effectInt[0]],
   (Odds)slotMachine.BoardNum[effectInt[1]],
   (Odds)slotMachine.BoardNum[effectInt[2]]);
    }

    public void BeforeSpin()
    {
        this.GetComponent<Image>().enabled = false;
    }

    private bool JudgeRole(params Odds[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            judgeArray.CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }

        if (a[0] == Odds.hololive)
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

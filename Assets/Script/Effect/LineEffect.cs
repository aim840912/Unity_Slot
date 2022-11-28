using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEffect : MonoBehaviour
{
    [SerializeField] int[] effectInt = new int[3];

    Image _image;

    JudgeArray judgeArray = new JudgeArray();

    public SlotMachine slotMachine;

    private void Awake()
    {
        _image = this.GetComponent<Image>();
    }
    public void AfterSpin()
    {
        _image.enabled = JudgeRole(SetArray());
    }

    public void BeforeSpin()
    {
        _image.enabled = false;
    }

    Odds[] SetArray()
    {
        Odds[] Odds_index = new Odds[effectInt.Length];
        for (int i = 0; i < effectInt.Length; i++)
        {
            Odds_index[i] = (Odds)slotMachine.BoardNum[effectInt[i]];
        }
        return Odds_index;
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

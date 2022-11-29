using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEffect : MonoBehaviour
{
    [SerializeField] int[] effectInt = new int[3];

    Image _lineImage;

    JudgeArray _judgeArray = new JudgeArray();

    [SerializeField] SlotMachine _slotMachine;

    void Awake()
    {
        _lineImage = this.GetComponent<Image>();
    }
    public void AfterSpin()
    {
        _lineImage.enabled = IsLineShow(SetGroup());
    }

    public void BeforeSpin()
    {
        _lineImage.enabled = false;
    }

    Odds[] SetGroup()
    {
        Odds[] Odds_index = new Odds[effectInt.Length];
        for (int i = 0; i < effectInt.Length; i++)
        {
            Odds_index[i] = (Odds)_slotMachine.BoardNum[effectInt[i]];
        }
        return Odds_index;
    }

    bool IsLineShow(params Odds[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            _judgeArray.CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
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

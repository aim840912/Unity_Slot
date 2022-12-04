using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineHandler : MonoBehaviour
{
    [SerializeField] LineEffectData _lineEffectData;
    [SerializeField] Image[] _lineImage;
    [SerializeField] SlotMachine _slotMachine;
    [SerializeField] Btn _btn;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _lineImage = new Image[_lineEffectData.Line.Length];
        for (int i = 0; i < _lineEffectData.Line.Length; i++)
        {
            _lineImage[i] = Instantiate(_lineEffectData.Line[i].LineImage, this.transform);
        }

        _btn.OnClicked += SpinEvent;
    }

    void SpinEvent(bool _isSpin)
    {
        if (!_isSpin)
        {
            CloseLine();
        }
        else
        {
            StartCoroutine(ShowLine());
        }
    }

    IEnumerator ShowLine()
    {
        yield return new WaitForSeconds(2f);
        AfterSpin();
    }

    void CloseLine()
    {
        BeforeSpin();
    }

    public void AfterSpin()
    {
        Odds[] indexLine;
        for (int i = 0; i < _lineImage.Length; i++)
        {
            indexLine = new Odds[_lineEffectData.Line[i].IndexLine.Length];

            for (var j = 0; j < indexLine.Length; j++)
            {
                indexLine[j] = (Odds)_slotMachine.BoardNum[_lineEffectData.Line[i].IndexLine[j]];
            }

            _lineImage[i].enabled = IsLineShow(indexLine);
        }
    }

    public void BeforeSpin()
    {
        for (int i = 0; i < _lineImage.Length; i++)
        {
            _lineImage[i].enabled = false;
        }
    }

    bool IsLineShow(params Odds[] a)
    {
        int anySeven = 0;
        int anyBar = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref anySeven, ref anyBar);
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

    void CheckEachCount(Odds a, ref int anySeven, ref int anyBar)
    {
        switch (a)
        {
            case Odds.gura:
            case Odds.ame:
                anySeven++;
                break;
            case Odds.ina:
            case Odds.kronii:
            case Odds.mumei:
                anyBar++;
                break;
        }
    }
}

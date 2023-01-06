using System.Collections;
using UnityEngine;

public class LineVisual : BaseSpin
{
    [SerializeField] LineData _lineData;
    [SerializeField] LineRenderer[] _line;
    [SerializeField] GameObject _lineObj;

    void Start()
    {
        InstantiateLineObj();
    }

    void InstantiateLineObj()
    {
        _line = new LineRenderer[_lineData.Lines.Length];
        for (int i = 0; i < _lineData.Lines.Length; i++)
        {
            _line[i] = Instantiate(_lineData.Lines[i].LineRenderer, _lineObj.transform);
        }
    }

    public override void Spin()
    {
        LineOff();
    }
    public override void Stop(int[] board)
    {
        StartCoroutine(LineOnCoro(board));
    }

    IEnumerator LineOnCoro(int[] boardNum)
    {
        yield return new WaitForSeconds(2f);
        LineOn(boardNum);
    }

    void LineOn(int[] boardNum)
    {
        Odds[] indexLine;
        for (int i = 0; i < _line.Length; i++)
        {
            indexLine = new Odds[_lineData.Lines[i].IndexLine.Length];

            for (var j = 0; j < indexLine.Length; j++)
            {
                indexLine[j] = (Odds)boardNum[_lineData.Lines[i].IndexLine[j]];
            }

            _line[i].enabled = IsLineOn(indexLine);
        }
    }

    void LineOff()
    {
        for (int i = 0; i < _line.Length; i++)
        {
            _line[i].enabled = false;
        }
    }

    bool IsLineOn(params Odds[] a)
    {
        int sevenAmount = 0;
        int barAmount = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref sevenAmount, ref barAmount);
        }

        if (a[0] == Odds.hololive)
        {
            return true;
        }
        else if (a[0] == a[1] && a[0] == a[2])
        {
            return true;
        }
        else if (barAmount == 3 || sevenAmount == 3)
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

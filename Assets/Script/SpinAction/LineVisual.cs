using System.Collections;
using UnityEngine;

public class LineVisual : BaseSpin
{
    [SerializeField] LineRendererData _lineRendererData;
    [SerializeField] LineRenderer[] _lineRender;
    [SerializeField] GameObject _lineObj;

    void Start()
    {
        GenerateLine();
    }

    void GenerateLine()
    {
        _lineRender = new LineRenderer[_lineRendererData.LineObjs.Length];
        for (int i = 0; i < _lineRendererData.LineObjs.Length; i++)
        {
            _lineRender[i] = Instantiate(_lineRendererData.LineObjs[i].LineRenderer, _lineObj.transform);
        }
    }

    public override void Spin(int[] boardNum, SpinType spinType)
    {
        if (spinType == SpinType.spin)
        {
            LineOff();
        }
        else
        {
            StartCoroutine(LineOnCoro(boardNum));
        }
    }

    IEnumerator LineOnCoro(int[] boardNum)
    {
        yield return new WaitForSeconds(2f);
        LineOn(boardNum);
    }

    void LineOn(int[] boardNum)
    {
        Odds[] indexLine;
        for (int i = 0; i < _lineRender.Length; i++)
        {
            indexLine = new Odds[_lineRendererData.LineObjs[i].IndexLine.Length];

            for (var j = 0; j < indexLine.Length; j++)
            {
                indexLine[j] = (Odds)boardNum[_lineRendererData.LineObjs[i].IndexLine[j]];
            }

            _lineRender[i].enabled = IsLineOn(indexLine);
        }
    }

    void LineOff()
    {
        for (int i = 0; i < _lineRender.Length; i++)
        {
            _lineRender[i].enabled = false;
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

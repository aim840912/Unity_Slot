using System.Linq;

public class CalcMultiple
{
    int _winLineCount = 3;
    int _gameBoardCount = 9;
    int[][] _eachLineIndexList = {
         new int[] { 0, 1, 2 },
         new int[] { 3, 4, 5 },
         new int[] { 6, 7, 8 },
         new int[] { 0, 3, 6 },
         new int[] { 1, 4, 7 },
         new int[] { 2, 5, 8 },
         new int[] { 0, 4, 8 },
         new int[] { 6, 4, 2 },
         };

    public int GetMultiple(int[] board)
    {
        int odds = 0;
        odds = CalcAllTheSame(NumConvertToOdds(board));

        if (odds > 0)
        {
            return odds;
        }

        foreach (var item in _eachLineIndexList)
        {
            var line = new int[item.Length];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = board[item[i]];
            }
            odds += CalcWinLine(NumConvertToOdds(line));
        }
        odds += CalcSevenCount(NumConvertToOdds(board));

        return odds;
    }

    Odds[] NumConvertToOdds(int[] convertThing)
    {
        Odds[] _oddsArr = new Odds[convertThing.Length];
        for (int i = 0; i < convertThing.Length; i++)
        {
            _oddsArr[i] = (Odds)convertThing[i];
        }
        return _oddsArr;
    }

    int CalcAllTheSame(params Odds[] a)
    {
        int numCount = a.Count(x => x == a[0]);

        if (numCount == _gameBoardCount)
        {
            return OddsDict.dictOverall[a[0]];
        }

        return CalcAllTheSameException(a);
    }

    int CalcAllTheSameException(params Odds[] a)
    {
        int countSeven = 0;
        int countBar = 0;
        int countFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CalcEachCount(a[i], ref countSeven, ref countBar, ref countFruit);
        }

        if (countSeven == _gameBoardCount)
        {
            return OddsDict.dictOverall[Odds.anySeven];
        }
        else if (countBar == _gameBoardCount)
        {
            return OddsDict.dictOverall[Odds.anyBar];
        }
        else if (countFruit == _gameBoardCount)
        {
            return OddsDict.dictOverall[Odds.anyFruit];
        }
        else
        {
            return 0;
        }
    }

    int CalcSevenCount(params Odds[] a)
    {
        int countRedSeven = a.Count(x => x == Odds.gura);
        int countBlueSeven = a.Count(x => x == Odds.ame);

        if (countRedSeven > 0 && countBlueSeven > 0)
        {
            return OddsDict.dictSpecial[Odds.anySeven][countRedSeven + countBlueSeven];
        }
        else if (countRedSeven == 0 && countBlueSeven > 1)
        {
            return OddsDict.dictSpecial[Odds.ame][countBlueSeven];
        }
        else if (countRedSeven > 1 && countBlueSeven == 0)
        {
            return OddsDict.dictSpecial[Odds.gura][countRedSeven];
        }
        return 0;
    }

    int CalcWinLine(params Odds[] a)
    {
        int countSeven = 0;
        int countBar = 0;
        int countFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CalcEachCount(a[i], ref countSeven, ref countBar, ref countFruit);
        }
        if (a[0] == a[1] && a[0] == a[2])
        {
            return OddsDict.dicNormal[a[0]];
        }
        else if (countSeven == _winLineCount)
        {
            return OddsDict.dicNormal[Odds.anySeven];
        }
        else if (countBar == _winLineCount)
        {
            return OddsDict.dicNormal[Odds.anyBar];
        }
        else if (a[0] == Odds.hololive)
        {
            if (a[0] == a[1]) return 5;
            else return 2;
        }
        return 0;
    }

    void CalcEachCount(Odds a, ref int countSeven, ref int countBar, ref int countFruit)
    {
        switch (a)
        {
            case Odds.gura:
            case Odds.ame:
                countSeven++;
                break;
            case Odds.ina:
            case Odds.kronii:
            case Odds.mumei:
                countBar++;
                break;
            case Odds.sana:
                break;
            default:
                countFruit++;
                break;
        }
    }
}

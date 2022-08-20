public class JudgeArray
{
    public int CheckAllTheSame(params int[] a)
    {
        int character;
        var num = 0;
        character = a[0];
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == a[0])
            {
                num += 1;
            }
        }
        if (num == 9)
        {
            return OddsDict.dicNormal[(Odds)a[0]];
        }
        else
        {
            return CheckBoard(a);
        }
    }
    public int CheckBoard(params int[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }
        if (anySeven == 9)
        {
            return OddsDict.dictOverall[Odds.anySeven];
        }
        else if (anySeven < 9 && anySeven > 1)
        {
            return CheckSeven(a);
        }
        else if (anyBar == 9)
        {
            return OddsDict.dictOverall[Odds.anyBar];
        }
        else if (anyFruit == 9)
        {
            return OddsDict.dictOverall[Odds.anyFruit];
        }
        else
        {
            return 0;
        }
    }

    public int CheckSeven(params int[] a)
    {
        int redSeven = 0;
        int blueSeven = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == (int)Odds.gura)
            {
                redSeven++;
            }
            else if (a[i] == (int)Odds.ame)
            {
                blueSeven++;
            }
        }
        if (redSeven > 0 && blueSeven > 0)
        {
            return OddsDict.dictSecpial[Odds.anySeven][redSeven + blueSeven];
        }
        else if (redSeven == 0 && blueSeven > 0)
        {
            return OddsDict.dictSecpial[Odds.ame][blueSeven];
        }
        else if (redSeven > 0 && blueSeven == 0)
        {
            return OddsDict.dictSecpial[Odds.gura][redSeven];

        }
        return 0;
    }

    public int JudgeThree(params int[] a)
    {
        int anySeven = 0;
        int anyBar = 0;
        int anyFruit = 0;

        for (int i = 0; i < a.Length; i++)
        {
            CheckEachCount(a[i], ref anySeven, ref anyBar, ref anyFruit);
        }
        if (a[0] == a[1] && a[0] == a[2])
        {
            return OddsDict.dicNormal[(Odds)a[0]];
        }
        else if (anySeven == 3)
        {
            return OddsDict.dicNormal[Odds.anySeven];
        }
        else if (anyBar == 3)
        {
            return OddsDict.dicNormal[Odds.anyBar];
        }
        else if (a[0] == (int)Odds.hololive)
        {
            if (a[0] == a[1]) return 5;
            else return 2;
        }
        return 0;
    }

    void CheckEachCount(int a, ref int anySeven, ref int anybar, ref int anyFruit)
    {
        switch (a)
        {
            case (int)Character.gura:
            case (int)Character.ame:
                anySeven++;
                break;
            case (int)Character.ina:
            case (int)Character.kronii:
            case (int)Character.mumei:
                anybar++;
                break;
            case (int)Character.sana:
                break;
            default:
                anyFruit++;
                break;
        }
    }
}

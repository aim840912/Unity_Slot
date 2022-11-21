public class CalculateMoney
{
    JudgeArray judgeArray = new JudgeArray();
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
    public int GetOddsTotal(int[] boardArr)
    {
        var oddsNum = 0;
        oddsNum = judgeArray.CheckAllTheSame(IntConvertToOddsArr(boardArr));

        if (oddsNum == 0)
        {
            foreach (var item in _eachLineIndexList)
            {
                var line = new int[item.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    line[i] = boardArr[item[i]];
                }
                oddsNum += judgeArray.JudgeThree(IntConvertToOddsArr(line));
            }
            oddsNum += judgeArray.CheckSeven(IntConvertToOddsArr(boardArr));
        }
        return oddsNum;
    }

    Odds[] IntConvertToOddsArr(int[] convertThing)
    {
        Odds[] _oddsArr = new Odds[9];
        for (int i = 0; i < convertThing.Length; i++)
        {
            _oddsArr[i] = (Odds)convertThing[i];

        }
        return _oddsArr;
    }
    Odds IntConvertToOdds(int convertThing)
    {
        return (Odds)convertThing;
    }
}

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
    public int GetOdds(int[] boardArr)
    {
        var oddsNum = 0;
        oddsNum = judgeArray.CheckAllTheSame(IntConvertToOdds(boardArr));

        if (oddsNum == 0)
        {
            foreach (var item in _eachLineIndexList)
            {
                var line = new int[item.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    line[i] = boardArr[item[i]];
                }
                oddsNum += judgeArray.JudgeThree(IntConvertToOdds(line));
            }
            oddsNum += judgeArray.CheckSeven(IntConvertToOdds(boardArr));
        }
        return oddsNum;
    }

    public Odds[] IntConvertToOdds(int[] convertThing)
    {
        Odds[] _oddsArr = new Odds[convertThing.Length];
        for (int i = 0; i < convertThing.Length; i++)
        {
            _oddsArr[i] = (Odds)convertThing[i];

        }
        return _oddsArr;
    }
}

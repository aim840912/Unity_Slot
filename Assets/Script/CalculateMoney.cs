using UnityEngine;

public class CalculateMoney
{
    [SerializeField] int oddsNum;
    JudgeArray judgeArray = new JudgeArray();

    public int GetOddsTotal(int[] boardArr)
    {
        oddsNum = 0;
        oddsNum = judgeArray.CheckAllTheSame(boardArr);

        if (oddsNum == 0)
        {
            foreach (var item in GetJudgeLine(boardArr))
            {
                oddsNum += judgeArray.JudgeThree(item);

            }
            oddsNum += judgeArray.CheckSeven(boardArr);
        }
        Debug.Log($"{oddsNum}");
        return oddsNum;
    }

    private int[][] GetJudgeLine(int[] boardArr)
    {
        int[][] eachLine =  {
             new int[] { boardArr[0], boardArr[1], boardArr[2] },
         new int[] { boardArr[3], boardArr[4], boardArr[5] },
         new int[] { boardArr[6], boardArr[7], boardArr[8] },
         new int[] { boardArr[0], boardArr[3], boardArr[6] },
         new int[] { boardArr[1], boardArr[4], boardArr[7] },
         new int[] { boardArr[2], boardArr[5], boardArr[8] },
         new int[] { boardArr[0], boardArr[4], boardArr[8] },
         new int[] { boardArr[6], boardArr[4], boardArr[2] },};

        return eachLine;
    }
}

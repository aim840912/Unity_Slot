using UnityEngine;

public class CalculateMoney : MonoBehaviour
{
    [SerializeField] int oddsNum;
    JudgeArray judgeArray = new JudgeArray();
    int GetOddsTotal(int[] boardArr)
    {
        int odds = judgeArray.CheckAllTheSame(boardArr);
        if (odds == 0)
        {
            foreach (var item in GetJudgeLine(boardArr))
            {
                oddsNum += judgeArray.JudgeThree(item);
            }
        }
        return oddsNum;
    }
    private int[,] GetJudgeLine(int[] boardArr)
    {
        int[,] eachLine = {
            { boardArr[0], boardArr[1], boardArr[2] },
         { boardArr[3], boardArr[4], boardArr[5] },
         { boardArr[6], boardArr[7], boardArr[8] },
         { boardArr[0], boardArr[3], boardArr[6] },
         { boardArr[1], boardArr[4], boardArr[7] },
         { boardArr[2], boardArr[5], boardArr[8] },
         { boardArr[0], boardArr[4], boardArr[8] },
         { boardArr[6], boardArr[4], boardArr[2] },
         };
        return eachLine;
    }
}

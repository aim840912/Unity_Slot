using UnityEngine;

public class GenerateBoard
{
    int[] boardNum = new int[9];

    public int[] GenerateNum(int minNum, int MaxNum)
    {
        for (var i = 0; i < boardNum.Length; i++)
        {
            boardNum[i] = Random.Range(minNum, MaxNum);
        }

        return boardNum;
    }
}

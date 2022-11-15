using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServer
{
    int[] GenerateNum();
    int CalculateOdds(int[] boardArr);
    int CalculateFinalMoney(int[] boardArr, int betMoney);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; set; }

    [SerializeField] public int[] boardNum = new int[9];

    [Range(0, 9)][SerializeField] int minRandomNum = 0;
    [Range(0, 10)][SerializeField] int maxRandomNum = 10;

    GenerateBoard generateBoard = new GenerateBoard();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public int[] GeneralBoard()
    {
        boardNum = generateBoard.GenerateNum(minRandomNum, maxRandomNum);
        return boardNum;
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         foreach (var item in boardNum)
    //         {
    //             Debug.Log(item);
    //         }
    //     }
    // }
}

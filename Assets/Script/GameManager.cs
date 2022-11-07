using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; set; }

    [SerializeField] public int[] boardNum = new int[9];

    [Range(0, 9)][SerializeField] int minRandomNum = 0;
    [Range(0, 10)][SerializeField] int maxRandomNum = 10;


    [SerializeField] public bool spinBool;

    GenerateBoard generateBoard = new GenerateBoard();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        spinBool = false;
    }

    public int[] GeneralBoard()
    {
        boardNum = generateBoard.GenerateNum(minRandomNum, maxRandomNum);
        return boardNum;
    }
}

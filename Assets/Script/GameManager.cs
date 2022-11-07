using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; set; }

    [SerializeField] public int[] boardNum = new int[9];



    [SerializeField] public bool spinBool;


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

    public int[] GeneralBoardNum()
    {
        boardNum = SimulationServer.Instance.GenerateNum();
        return boardNum;
    }
}

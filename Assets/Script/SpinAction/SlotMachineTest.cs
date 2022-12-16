using UnityEngine;

public class SlotMachineTest : MonoBehaviour
{
    int[] BoardNum { get; set; }

    bool _isSpin;
    void Awake()
    {
        LoadBoardNum(BoardNum);
    }
    protected void LoadBoardNum(int[] boardNum)
    {
        BoardNum = SaveManager.LoadBoard().boardNum;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpinProcess();
        }
    }

    BaseAction[] baseActionArray;
    void SpinProcess()
    {
        GetNum();
        _isSpin = !_isSpin;
        baseActionArray = GetComponents<BaseAction>();
        foreach (BaseAction baseAction in baseActionArray)
        {
            baseAction.BoardNum = BoardNum;
            baseAction.SpinEvent();
            baseAction.isSpin = _isSpin;
        }

    }

    Server _server = new SimulationServer();
    public void GetNum()
    {
        int a;
        BoardNum = _server.GenerateNum();
        StoreBoardNum(BoardNum);
        _server.GetFinalMoney(0, out a);
    }

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

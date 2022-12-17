using UnityEngine;

public class SlotMachineTest : MonoBehaviour
{
    int[] _boardNum;
    bool _isSpin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isSpin = !_isSpin;
            SpinProcess(_isSpin);
        }
    }

    BaseAction[] baseActionArray;
    void SpinProcess(bool isSpin)
    {
        GetNum();
        baseActionArray = GetComponents<BaseAction>();
        foreach (BaseAction baseAction in baseActionArray)
        {
            baseAction.SpinEvent(_boardNum, isSpin);
        }
    }

    Server _server = new SimulationServer();
    public void GetNum()
    {
        _boardNum = _server.GenerateNum();
        StoreBoardNum(_boardNum);
    }

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

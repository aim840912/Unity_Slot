using UnityEngine;

public class SlotMachineTest : MonoBehaviour
{
    int[] _boardNum;
    bool _isSpin;

    BaseAction[] baseActionArray;
    void Start()
    {
        baseActionArray = GetComponents<BaseAction>();
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;
        SpinSOP(_isSpin);
    }

    void SpinSOP(bool isSpin)
    {
        if (!isSpin)
        {
            GetServerData();
            UpdateUI();
        }
        foreach (BaseAction baseAction in baseActionArray)
        {
            baseAction.SpinEvent(_boardNum, isSpin);
        }
    }

    Server _server = new SimulationServer();
    [SerializeField] UIControlTest _uIControlTest;
    public void GetServerData()
    {
        _boardNum = _server.GenerateNum();
        StoreBoardNum(_boardNum);
    }

    public void UpdateUI()
    {
        _uIControlTest.UpdateUI(_server);
    }

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

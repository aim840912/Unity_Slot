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
    void Start()
    {
        baseActionArray = GetComponents<BaseAction>();
    }

    void OnSpinClick()
    {
        _isSpin = !_isSpin;
        SpinProcess(_isSpin);
    }


    void SpinProcess(bool isSpin)
    {
        if (isSpin)
        {
            GetNum();
        }
        else
        {
            UpdateUI();
        }

        foreach (BaseAction baseAction in baseActionArray)
        {
            baseAction.SpinEvent(_boardNum, isSpin);
        }
    }

    Server _server = new SimulationServer();
    [SerializeField] UIControlTest _uIControlTest;
    public void GetNum()
    {
        _boardNum = _server.GenerateNum();
        StoreBoardNum(_boardNum);
    }

    public void UpdateUI()
    {
        int BetMoney = _uIControlTest.GetInputValue();
        int win = 0;
        int finalMoney = _server.GetFinalMoney(BetMoney, out win);
        _uIControlTest.UpdateUI(finalMoney, win);
    }


    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

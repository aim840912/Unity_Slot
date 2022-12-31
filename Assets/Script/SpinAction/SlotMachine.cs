using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    int[] _boardNum;
    bool _isSpin;
    BaseSpin[] _baseActionArray;

    private void Start()
    {
        _baseActionArray = GetComponents<BaseSpin>();
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;
        if (_isSpin)
        {
            foreach (BaseSpin baseAction in _baseActionArray)
            {
                baseAction.BoardNum = _boardNum;
                baseAction.Spin();
            }
        }
        else
        {
            GetGameBoardNumAndStore();
            UpdateUI();
            foreach (BaseSpin baseAction in _baseActionArray)
            {
                baseAction.BoardNum = _boardNum;
                baseAction.Stop();
            }
        }
    }

    Server _server = new SimulationServer();

    void GetGameBoardNumAndStore()
    {
        _boardNum = _server.GenerateGameBoard();
        StoreBoardNum(_boardNum);
    }


    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
    [SerializeField] UIControl _uIControl;
    void UpdateUI()
    {
        _uIControl.UpdateUI(_server);
    }
}

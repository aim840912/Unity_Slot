using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    int[] _boardNum;
    bool _isSpin;
    BaseSpin[] _baseActionArray;

    public BoardVisual boardVisual;
    private void Start()
    {
        _baseActionArray = GetComponents<BaseSpin>();
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;
        if (_isSpin)
        {
            Spin(BaseSpin.SpinType.spin);
        }
        else
        {
            Spin(BaseSpin.SpinType.stop);
        }
    }

    void Spin(BaseSpin.SpinType spinType)
    {
        if (spinType == BaseSpin.SpinType.stop)
        {
            GetServerDataAndStore();
            UpdateUI();
        }
        foreach (BaseSpin baseAction in _baseActionArray)
        {
            baseAction.BoardNum = _boardNum;
            baseAction.Spin(spinType);
        }
    }

    Server _server = new SimulationServer();

    public void GetServerDataAndStore()
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
    public void UpdateUI()
    {
        _uIControl.UpdateUI(_server);
    }
}

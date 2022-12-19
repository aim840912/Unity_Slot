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
        SpinSOP(_isSpin);
    }

    void SpinSOP(bool isSpin)
    {
        if (!isSpin)
        {
            GetServerData();
            UpdateUI();
        }
        foreach (BaseSpin baseAction in _baseActionArray)
        {
            baseAction.SpinEvent(_boardNum, isSpin);
        }
    }

    Server _server = new SimulationServer();
    [SerializeField] UIControl _uIControl;
    public void GetServerData()
    {
        _boardNum = _server.GenerateNum();
    }
    public void UpdateUI()
    {
        _uIControl.UpdateUI(_server);
    }
}

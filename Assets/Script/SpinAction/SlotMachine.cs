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
            GetServerData();
            UpdateUI();
        }
        foreach (BaseSpin baseAction in _baseActionArray)
        {
            baseAction.Spin(_boardNum, spinType);
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

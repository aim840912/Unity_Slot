using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;
    private void Start()
    {
        _baseSpinArray = GetComponents<BaseSpin>();
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;

        if (_isSpin)
        {
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Spin();
            }
        }
        else
        {
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Stop(GetGameBoardNumAndStore());
            }

            Calc();
            UpdatePlayerInform();
        }
    }

    SimulationServer _server = new SimulationServer();

    int[] GetGameBoardNumAndStore()
    {
        return _server.GenerateGameBoardAndSave();
    }

    [SerializeField] UIControl _uIControl;

    void Calc()
    {
        _server.CalcWinMoneyAndSave(_uIControl.GetInputValue(_server));
    }
    void UpdatePlayerInform()
    {
        _uIControl.UpdateUI(_server);
    }
}

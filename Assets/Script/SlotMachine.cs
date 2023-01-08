using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;

    void Start()
    {
        _baseSpinArray = GetComponents<BaseSpin>();
        spinToggle.onValueChanged.AddListener(SpinToggleOnClick);
    }

    SimulationServer _server = new SimulationServer();
    [SerializeField] InputManager _inputManager;

    #region 作法1

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;

        if (_isSpin)
        {
            _server.ServerProcess(_inputManager.GetInputValue());

            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Spin();
            }
        }
        else
        {
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Stop(_server.GetServerBoardNum());
            }

            UpdatePlayerInform();
        }
    }

    #endregion

    #region 作法_2

    [SerializeField] BoardVisual boardVisual;
    [SerializeField] LineVisual lineVisual;
    [SerializeField] Toggle spinToggle;

    void SpinToggleOnClick(bool isSpin)
    {
        if (isSpin)
        {
            _server.ServerProcess(_inputManager.GetInputValue());
            Spin(boardVisual);
            Spin(lineVisual);
        }
        else
        {
            Stop(boardVisual);
            Stop(lineVisual);
            UpdatePlayerInform();
        }
    }

    void Spin(BaseSpin baseSpin)
    {
        baseSpin.Spin();
    }
    void Stop(BaseSpin baseSpin)
    {
        baseSpin.Stop(_server.GetServerBoardNum());
    }

    #endregion

    [SerializeField] UIManager _uiManager;

    void UpdatePlayerInform()
    {
        _uiManager.UpdatedUI(_server);
    }
}

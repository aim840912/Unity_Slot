using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;

    void Start()
    {
        _baseSpinArray = GetComponents<BaseSpin>();
    }

    SimulationServer _server = new SimulationServer();
    [SerializeField] InputManager _inputManager;

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

    [SerializeField] UIManager _uiManager;

    void UpdatePlayerInform()
    {
        _uiManager.UpdatedUI(_server);
    }
}

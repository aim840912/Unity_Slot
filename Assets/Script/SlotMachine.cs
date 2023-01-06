using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;
    int[] boardNum;

    private void Start()
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
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Spin();
            }
            _server.ServerProcess(_inputManager.GetInputValue());
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

    [SerializeField] UpdateUI _updateUI;

    void UpdatePlayerInform()
    {
        _updateUI.UpdatedUI(_server);
    }
}

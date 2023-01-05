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

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;

        if (_isSpin)
        {
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Spin();
            }
            GetInputField();
            GetGameBoardNumAndStore();
        }
        else
        {
            foreach (BaseSpin baseAction in _baseSpinArray)
            {
                baseAction.Stop(boardNum);
            }

            UpdatePlayerInform();
        }
    }

    SimulationServer _server = new SimulationServer();

    void GetGameBoardNumAndStore()
    {
        boardNum = _server.GenerateGameBoardAndSave();
    }

    [SerializeField] UpdateUI _updateUI;
    [SerializeField] InputManager _inputManager;
    void GetInputField()
    {
        _server.GetInputValue(_inputManager.GetInputValue());
    }
    void UpdatePlayerInform()
    {
        _updateUI.UpdatedUI(_server);
    }
}

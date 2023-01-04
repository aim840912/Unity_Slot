using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;
    int[] boardNum;

    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;

    private void Start()
    {
        _baseSpinArray = GetComponents<BaseSpin>();
    }

    private void Update()
    {

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

    [SerializeField] UIControl _uIControl;

    void GetInputField()
    {
        if (_uIControl.CanSpin())
        {
            _server.GetInputValue(int.Parse(_inputBet.text));
        }
        else
        {
            _server.GetInputValue(0);
        }

    }
    void UpdatePlayerInform()
    {
        _uIControl.UpdateUI(_server);
    }
}

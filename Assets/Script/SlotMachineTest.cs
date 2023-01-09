using UnityEngine;

// ! 這個方法有比 SlotMachine.cs 好嗎 ?
public class SlotMachineTest : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseSpinArray;

    [SerializeField] PlayerUI _playerUI;
    SimulationServer _server = new SimulationServer();
    [SerializeField] InputUnit _inputUnit;

    void Start()
    {
        _baseSpinArray = GetComponents<BaseSpin>();
    }

    void UpdatePlayerInform()
    {
        _playerUI.UpdatedPlayerUI(_server);
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;

        if (_isSpin)
        {
            _server.ServerProcess(_inputUnit.GetInputValue());

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
}

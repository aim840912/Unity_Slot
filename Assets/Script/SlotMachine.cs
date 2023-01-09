using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] PlayerUI _playerUI;
    SimulationServer _server = new SimulationServer();
    [SerializeField] InputUnit _inputUnit;
    [SerializeField] BoardVisual _boardVisual;
    [SerializeField] LineVisual _lineVisual;
    [SerializeField] Toggle _spinToggle;

    void Start()
    {
        _spinToggle.onValueChanged.AddListener(SpinToggleOnClick);
        UpdatePlayerInform();
    }

    void UpdatePlayerInform()
    {
        _playerUI.UpdatedPlayerUI(_server);
    }

    void SpinToggleOnClick(bool isSpin)
    {
        if (isSpin)
        {
            _server.ServerProcess(_inputUnit.GetInputValue());
            Spin(_boardVisual);
            Spin(_lineVisual);
        }
        else
        {
            Stop(_boardVisual);
            Stop(_lineVisual);
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
}

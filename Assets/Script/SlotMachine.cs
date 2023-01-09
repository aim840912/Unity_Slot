using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] PlayerUI _playerUI;
    SimulationServer _server = new SimulationServer();
    [SerializeField] InputUnit _inputUnit;
    [SerializeField] BoardVisual boardVisual;
    [SerializeField] LineVisual lineVisual;
    [SerializeField] Toggle spinToggle;

    void Start()
    {
        spinToggle.onValueChanged.AddListener(SpinToggleOnClick);
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
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] PlayerUI _playerUI;
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
        _playerUI.UpdatedPlayerUI(SimulationServer.getInstance());
    }

    void SpinToggleOnClick(bool isSpin)
    {
        if (isSpin)
        {
            StartSpin();
        }
        else
        {
            StartCoroutine(Stop());
        }
    }
    void StartSpin()
    {
        SimulationServer.getInstance().ServerProcess(_inputUnit.GetInputValue());
        Spin(_boardVisual);
        Spin(_lineVisual);
    }

    IEnumerator Stop()
    {
        Stop(_boardVisual);
        yield return new WaitForSeconds(2f);
        Stop(_lineVisual);
        UpdatePlayerInform();
    }

    void Spin(BaseSpin baseSpin)
    {
        baseSpin.Spin();
    }

    void Stop(BaseSpin baseSpin)
    {
        baseSpin.Stop(SimulationServer.getInstance().GetServerBoardNum());
    }
}

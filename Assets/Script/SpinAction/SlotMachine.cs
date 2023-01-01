using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    bool _isSpin;
    BaseSpin[] _baseActionArray;
    private void Start()
    {
        _baseActionArray = GetComponents<BaseSpin>();
    }

    public void SpinBtnClick()
    {
        _isSpin = !_isSpin;
        if (_isSpin)
        {
            foreach (BaseSpin baseAction in _baseActionArray)
            {
                baseAction.Spin();
            }
        }
        else
        {
            foreach (BaseSpin baseAction in _baseActionArray)
            {
                baseAction.BoardNum = GetGameBoardNumAndStore();
                baseAction.Stop();
            }

            UpdateUI();
        }
    }

    Server _server = new SimulationServer();

    int[] GetGameBoardNumAndStore()
    {
        return _server.GenerateGameBoardAndStore();
    }

    [SerializeField] UIControl _uIControl;
    void UpdateUI()
    {
        _uIControl.UpdateUI(_server);
    }
}

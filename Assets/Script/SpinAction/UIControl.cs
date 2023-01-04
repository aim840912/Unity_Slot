using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] CheckValue _checkValue;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    bool isShowing;
    void Start()
    {
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money}";
    }

    public bool CanSpin()
    {
        return _checkValue.CanSpin();
    }

    public void UpdateUI(SimulationServer server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = server.GetPlayerMoneyFromData();

        _winMoneyText.text = $"{winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }
}

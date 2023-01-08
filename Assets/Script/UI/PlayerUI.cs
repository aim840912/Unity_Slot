using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    void Start()
    {
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money}";
    }

    public void UpdatedUI(SimulationServer server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = server.GetPlayerMoneyFromData();

        _winMoneyText.text = $"{winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }
}

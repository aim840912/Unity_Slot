using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

    public void UpdatedPlayerUI(SimulationServer server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = server.PlayerMoney;

        _winMoneyText.text = $"{winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }
}

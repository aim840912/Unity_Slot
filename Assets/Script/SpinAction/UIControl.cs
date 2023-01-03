using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{

    [SerializeField] Image _showImage;

    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;
    void Start()
    {
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money}";
    }

    public void IsShowingOddsImage()
    {
        _showImage.enabled = !_showImage.enabled;
    }

    public int GetInputValue(SimulationServer server)
    {
        if (_inputBet.text == "")
            return 0;

        int betMoney = int.Parse(_inputBet.text);

        if (betMoney * 8 > server.GetPlayerMoneyFromData())
        {
            return 0;
        }
        return betMoney < 0 ? 0 : betMoney;
    }

    public void UpdateUI(SimulationServer server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = server.GetPlayerMoneyFromData();

        _winMoneyText.text = $"{winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }
}

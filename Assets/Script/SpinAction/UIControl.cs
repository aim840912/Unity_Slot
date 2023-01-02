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

    public int GetInputValue()
    {
        if (_inputBet.text == "")
            return 0;

        int betMoney = int.Parse(_inputBet.text);

        if (betMoney * 8 > SaveManager.CurrentSaveData.money)
        {
            return 0;
        }
        return betMoney < 0 ? 0 : betMoney;
    }

    public void UpdateUI(SimulationServer server)
    {
        int winMoney = server.WinMoney;
        int FinalMoney = server.GetPlayerMoneyFromData();

        _playerMoneyText.text = $"{FinalMoney}";
        _winMoneyText.text = $"{winMoney}";
    }
}

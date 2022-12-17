using UnityEngine;
using TMPro;

public class UIControlTest : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;
    void Start()
    {
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money}";
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

    public void UpdateUI(Server server)
    {
        int winMoney;
        int FinalMoney = server.GetFinalMoney(GetInputValue(), out winMoney);

        _playerMoneyText.text = $"{FinalMoney}";
        _winMoneyText.text = $"{winMoney}";
    }
}

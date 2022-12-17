using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControlTest : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;

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

    public void InitUI()
    {
        _playerMoneyText.text = $"{SaveManager.LoadPlayerData().money}";
    }

    public void UpdateUI()
    {
        _playerMoneyText.text = $"{0}";
        _winMoneyText.text = $"{0}";
    }
}

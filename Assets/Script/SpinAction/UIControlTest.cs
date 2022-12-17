using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControlTest : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_InputField _inputBet;
    [SerializeField] TMP_Text _winMoneyText;
    [SerializeField] TMP_Text _playerMoneyText;
    int BetMoney { get { return GetInputValue(); } }
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



    public void UpdateUI(int playerMoney, int winMoney)
    {
        _playerMoneyText.text = $"{playerMoney}";
        _winMoneyText.text = $"{winMoney}";
    }
}

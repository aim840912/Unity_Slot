using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CheckValue : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputBet;

    void Reset()
    {
        _inputBet = this.GetComponent<TMP_InputField>();
    }

    void Start()
    {
        _inputBet.onValueChanged.AddListener(delegate { CheckInputValue(); });
    }

    public bool CanSpin()
    {
        if (_inputBet.image.color == Color.red)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void CheckInputValue()
    {
        if (_inputBet.text == "")
            _inputBet.image.color = Color.red;

        int betMoney = int.Parse(_inputBet.text);

        if (betMoney * 8 > SaveManager.LoadPlayerData().money || betMoney < 0)
        {
            _inputBet.image.color = Color.red;
        }
        else
        {
            _inputBet.image.color = Color.white;
        }
    }
}

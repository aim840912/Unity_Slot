using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputBet;

    void Reset()
    {
        _inputBet = this.GetComponent<TMP_InputField>();
    }

    void Start()
    {
        _inputBet.onValueChanged.AddListener(delegate { CheckInputValue(_inputBet); });
    }

    public int GetInputValue()
    {
        if (CheckInputValue(_inputBet))
        {
            return int.Parse(_inputBet.text);
        }
        else
        {
            return 0;
        }
    }

    bool CheckInputValue(TMP_InputField inputBet)
    {
        if (inputBet.text == "")
        {
            inputBet.image.color = Color.red;
            return false;
        }

        int inputValue = int.Parse(inputBet.text);

        if (inputValue * 8 > SaveManager.LoadPlayerData().money || inputValue < 0)
        {
            inputBet.image.color = Color.red;
            return false;
        }
        else
        {
            inputBet.image.color = Color.white;
            return true;
        }
    }
}

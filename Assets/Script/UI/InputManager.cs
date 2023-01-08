using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _betInput;

    void Start()
    {
        _betInput.onValueChanged.AddListener(delegate { CheckInputValue(_betInput); });
    }

    public int GetInputValue()
    {
        if (CheckInputValue(_betInput))
        {
            return int.Parse(_betInput.text);
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
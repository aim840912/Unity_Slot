using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{

    [SerializeField] Image[] board = new Image[9];
    [SerializeField] public int[] boardNum = new int[9];
    [SerializeField] GameObject effectObj;
    [SerializeField] GameObject spinObj;

    [Header("UI")]
    [SerializeField] Btn setupBtn;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text winText;

    bool isSpin = false;

    Spin[] spinGroup;
    IEffect[] temp;

    void Start()
    {
        spinGroup = spinObj.GetComponentsInChildren<Spin>();
        temp = effectObj.GetComponentsInChildren<IEffect>();
    }

    public void SetupBtn()
    {
        isSpin = !isSpin;
        setupBtn.SetupButton();

        if (isSpin)
        {
            StartSpin();
        }
        else
        {
            StopSpin();
        }
    }

    public void StartSpin()
    {
        foreach (var item in temp)
        {
            item.BeforeSpin();
        }

        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", true);
        }
    }

    public void StopSpin()
    {
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", false);
        }
        StartCoroutine(GetServerNum());
    }

    IEnumerator GetServerNum()
    {
        yield return new WaitForSeconds(0.5f);

        IServer server = new SimulationServer();
        boardNum = server.GenerateNum();

        int oddsTotal = server.CalculateOdds(boardNum);
        int finalWinMoney = server.CalculateFinalMoney(boardNum, GetInputValue());

        Debug.Log(oddsTotal);

        for (var i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Image>().sprite = DictNumToImg.numToImg[boardNum[i]];
        }
        yield return new WaitForSeconds(2.5f);
        foreach (var item in temp)
        {
            item.AfterSpin();
        }
        winText.text = finalWinMoney.ToString();
    }

    int GetInputValue()
    {
        if (inputField.text == "")
        {
            return 0;
        }
        else
        {
            return int.Parse(inputField.text);
        }

    }
}

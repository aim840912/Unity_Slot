using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public static SlotMachine Instance { get; set; }
    [SerializeField] Image[] board = new Image[9];
    [SerializeField] int[] boardNum = new int[9];
    [SerializeField] GameObject effectObj;
    [SerializeField] GameObject spinObj;

    [Header("UI")]
    [SerializeField] GameObject spinBtn;
    [SerializeField] GameObject stopBtn;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text winText;


    Spin[] spinGroup;
    IEffect[] temp;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        spinGroup = spinObj.GetComponentsInChildren<Spin>();
        temp = effectObj.GetComponentsInChildren<IEffect>();
    }


    public void StartSpin()
    {
        foreach (var item in temp)
        {
            item.BeforeSpin();
        }

        spinBtn.SetActive(false);
        stopBtn.SetActive(true);

        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", true);
        }
    }

    public void StopSpin()
    {
        spinBtn.SetActive(true);
        stopBtn.SetActive(false);
        foreach (var item in spinGroup)
        {
            item.GetComponent<Animator>().SetBool("Rolling", false);
        }
        StartCoroutine(GetServerNum());
    }

    IEnumerator GetServerNum()
    {
        yield return new WaitForSeconds(0.5f);

        SimulationServer.Instance.GenerateNum();
        boardNum = SimulationServer.Instance.boardNum;

        int oddsTotal = SimulationServer.Instance.CalculateOdds(boardNum);

        int finalWinMoney = SimulationServer.Instance.CalculateFinalMoney(boardNum, GetInputValue());

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

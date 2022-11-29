using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    [SerializeField] Button _spinButton;
    [SerializeField] Button _oddsButton;
    [SerializeField] Image _oddsImage;
    [SerializeField] SlotMachine _slotMachine;

    bool _isSpin = false;
    float InteractableTime = 2;

    void Start()
    {
        _spinButton.onClick.AddListener(delegate ()
        {
            SetupButton();
        });
        _oddsButton.onClick.AddListener(delegate ()
        {
            IsShowingOddsImage();
        });
    }

    private Coroutine coroutine;

    void SetupButton()
    {
        SetSpin();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(DelayInteractableButton());
    }

    IEnumerator DelayInteractableButton()
    {
        _spinButton.interactable = false;
        yield return new WaitForSeconds(InteractableTime);
        _spinButton.interactable = true;
        coroutine = null;
    }

    void IsShowingOddsImage()
    {
        _oddsImage.enabled = !_oddsImage.enabled;
    }

    void SetSpin()
    {
        _isSpin = !_isSpin;

        if (_isSpin)
        {
            _slotMachine.StartSpin();
        }
        else
        {
            _slotMachine.StopSpin();
        }
    }
}

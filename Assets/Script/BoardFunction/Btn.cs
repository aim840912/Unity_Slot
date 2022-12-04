using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Btn : MonoBehaviour
{
    [SerializeField] Button _spinButton;
    [SerializeField] Button _oddsButton;
    [SerializeField] Image _oddsImage;
    public event Action<bool> OnClicked;
    bool _isSpin;
    float _interactableTime = 2;
    [SerializeField] SlotMachine _slotMachine;
    [SerializeField] SpinHandler _spinHandler;
    [SerializeField] LineHandler _lineHandler;
    Coroutine _coroutine;
    void Start()
    {
        AddInterfaceAction(_slotMachine);
        AddInterfaceAction(_spinHandler);
        AddInterfaceAction(_lineHandler);
        _spinButton.onClick.AddListener(SetupButton);

        _oddsButton.onClick.AddListener(IsShowingOddsImage);
    }

    public void AddInterfaceAction(ISpin spin)
    {
        OnClicked += spin.SpinEvent;
    }

    void SetupButton()
    {
        OnClicked?.Invoke(_isSpin);

        _isSpin = !_isSpin;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(DelayInteractableButton());
    }

    IEnumerator DelayInteractableButton()
    {
        _spinButton.interactable = false;
        yield return new WaitForSeconds(_interactableTime);
        _spinButton.interactable = true;
        _coroutine = null;
    }

    void IsShowingOddsImage()
    {
        _oddsImage.enabled = !_oddsImage.enabled;
    }
}

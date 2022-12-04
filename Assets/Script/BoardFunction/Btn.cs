using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
public class Btn : MonoBehaviour
{
    [SerializeField] Button _spinButton;
    [SerializeField] Button _oddsButton;
    [SerializeField] Image _oddsImage;
    public event Action<bool> OnClicked;
    [SerializeField] UnityEvent _unityEvent;
    bool _isSpin;
    float _interactableTime = 2;
    [SerializeField] SlotMachine _slotMachine;
    [SerializeField] SpinHandler _spinHandler;
    [SerializeField] LineHandler _lineHandler;
    Coroutine _coroutine;
    void Start()
    {
        _unityEvent.Invoke();

        _spinButton.onClick.AddListener(SetupButton);

        _oddsButton.onClick.AddListener(IsShowingOddsImage);
    }
    public void AddISpinAction(ISpin spin)
    {
        OnClicked += spin.SpinEvent;
    }

    public void SetupSpinEvent()
    {
        AddISpinAction(_slotMachine);
        AddISpinAction(_spinHandler);
        AddISpinAction(_lineHandler);
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

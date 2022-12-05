using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SpinButton : MonoBehaviour
{
    public event Action<bool> OnClicked;
    [SerializeField] Button _button;
    float _interactableTime = 2;
    bool _isSpin;
    Coroutine _coroutine;

    [SerializeField] SlotMachine _slotMachine;
    [SerializeField] SpinHandler _spinHandler;
    [SerializeField] LineHandler _lineHandler;
    private void Reset()
    {
        _button = this.GetComponent<Button>();
    }
    void Start()
    {

        SetupButtonEvent();
    }
    public void SetupButtonEvent()
    {
        AddISpinAction(_slotMachine, _spinHandler, _lineHandler);
        _button.onClick.AddListener(SetupButton);
    }

    public void AddISpinAction(params ISpin[] spin)
    {
        for (var i = 0; i < spin.Length; i++)
        {
            OnClicked += spin[i].SpinEvent;
        }
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
        _button.interactable = false;
        yield return new WaitForSeconds(_interactableTime);
        _button.interactable = true;
        _coroutine = null;
    }

}

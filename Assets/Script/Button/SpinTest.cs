using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SpinTest : MonoBehaviour
{
    public event Action<bool> OnClicked;
    [SerializeField] Button _button;
    float _interactableTime = 2;
    Coroutine _coroutine;

    void BtnProcess()
    {
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

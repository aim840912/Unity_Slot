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

    void Start()
    {
        _spinButton.onClick.AddListener(SetupButton);

        _oddsButton.onClick.AddListener(IsShowingOddsImage);
    }

    private Coroutine coroutine;

    public void AddAction(Action<bool> action)
    {
        OnClicked += action;
    }

    void SetupButton()
    {
        OnClicked?.Invoke(_isSpin);

        _isSpin = !_isSpin;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(DelayInteractableButton());
    }

    IEnumerator DelayInteractableButton()
    {
        _spinButton.interactable = false;
        yield return new WaitForSeconds(_interactableTime);
        _spinButton.interactable = true;
        coroutine = null;
    }

    void IsShowingOddsImage()
    {
        _oddsImage.enabled = !_oddsImage.enabled;
    }
}

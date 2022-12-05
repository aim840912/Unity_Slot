using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
public class OddsButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Image _oddsImage;
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
        _button.onClick.AddListener(IsShowingOddsImage);
    }


    void IsShowingOddsImage()
    {
        _oddsImage.enabled = !_oddsImage.enabled;
    }
}

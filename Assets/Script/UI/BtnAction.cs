using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnAction : MonoBehaviour
{
    [SerializeField] Button _button;
    float _interactableTime = 2;
    Coroutine _coroutine;
    void Reset()
    {
        _button = this.GetComponent<Button>();
    }
    void Start()
    {
        _button.onClick.AddListener(BtnProcess);
    }

    public void BtnProcess()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(SetDelayInteractable());
    }

    IEnumerator SetDelayInteractable()
    {
        _button.interactable = false;
        yield return new WaitForSeconds(_interactableTime);
        _button.interactable = true;
        _coroutine = null;
    }
}

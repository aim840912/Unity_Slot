using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InteractButton : MonoBehaviour
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
        _button.onClick.AddListener(StartDelayInteractable);
    }

    public void StartDelayInteractable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(SetDelayInteractableTime());
    }

    IEnumerator SetDelayInteractableTime()
    {
        _button.interactable = false;
        yield return new WaitForSeconds(_interactableTime);
        _button.interactable = true;
        _coroutine = null;
    }
}

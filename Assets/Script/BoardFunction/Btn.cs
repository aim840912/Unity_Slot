using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Btn : MonoBehaviour
{
    [SerializeField] private Button _button;
    public float InteractableTime
    {
        get { return 3; }
    }
    private void Reset()
    {
        _button = this.GetComponent<Button>();
    }

    private Coroutine coroutine;

    public void SetupButton()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(DelayInteractableButton());
    }

    private IEnumerator DelayInteractableButton()
    {
        _button.interactable = false;
        yield return new WaitForSeconds(InteractableTime);
        _button.interactable = true;
        coroutine = null;
    }
}

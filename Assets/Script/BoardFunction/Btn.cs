using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Btn : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Reset()
    {
        button = this.GetComponent<Button>();
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
        button.interactable = false;
        yield return new WaitForSeconds(3);
        button.interactable = true;
        coroutine = null;
    }
}

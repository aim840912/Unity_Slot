using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShowImageButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Image _showImage;
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
        _showImage.enabled = !_showImage.enabled;
    }
}

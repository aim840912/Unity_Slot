using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SpinToggle : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    [SerializeField] Text _toggleText;

    void Reset()
    {
        _toggle = this.GetComponent<Toggle>();
    }

    void Start()
    {
        _toggle.onValueChanged.AddListener(SetToggleText);
    }

    void SetToggleText(bool isOn)
    {
        if (isOn)
        {
            _toggleText.text = "Stop";
        }
        else
        {
            _toggleText.text = "Spin";
        }
    }
}

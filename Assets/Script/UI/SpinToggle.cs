using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SpinToggle : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    [SerializeField] Text _toggleText;

    string _startSpin = "Spin";
    string _stopSpin = "Stop";

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
            _toggleText.text = _stopSpin;
        }
        else
        {
            _toggleText.text = _startSpin;
        }
    }
}

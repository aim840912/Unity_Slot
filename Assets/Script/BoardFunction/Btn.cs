using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{

    void BtnState()
    {
        this.GetComponent<Button>().interactable = true;
    }

    void OnEnable()
    {
        this.GetComponent<Button>().interactable = false;
        this.Invoke("BtnState", 3f);
    }
}

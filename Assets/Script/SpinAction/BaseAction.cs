using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public abstract class BaseAction : MonoBehaviour
{
    public abstract void SpinEvent();

    public int[] BoardNum { get; set; }

    public bool isSpin;

    private void Awake()
    {
        BoardNum = SaveManager.LoadBoard().boardNum;
    }
}

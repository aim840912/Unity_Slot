using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotProcess : MonoBehaviour
{
    int[] BoardNum { get; set; }

    BaseAction[] _baseActions;

    void Start()
    {
        GetComponents<BaseAction>();
    }
}

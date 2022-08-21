using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();

    }
}

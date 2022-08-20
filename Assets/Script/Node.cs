using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public Vector2 pos => transform.position;

    [SerializeField] TextMeshPro numberText;

    [SerializeField] int num;

    private void Start()
    {
        num = Random.Range(0, 2);
        numberText.text = num.ToString();
    }

    public int GetValue()
    {
        return num;
    }
}

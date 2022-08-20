using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    [SerializeField] Image[] image;
    [SerializeField] Sprite[] sprites;

    // [SerializeField] Character[] characters = { Character.gura };
    private void Awake()
    {

    }
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Art");

    }

    private void Update()
    {
    }
}

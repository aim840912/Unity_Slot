using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    [SerializeField]
    RectTransform pos;

    [SerializeField]
    int rollingSpeed = 250;

    private void Start()
    {
        pos = GetComponent<RectTransform>();
    }

    private void Update()
    {

        if (pos.localPosition.y > -100)
        {
            pos.Translate(new Vector2(0, -1) * Time.deltaTime * rollingSpeed);
        }
        else
        {
            pos.localPosition = new Vector2(0, 100);
        }
    }
}

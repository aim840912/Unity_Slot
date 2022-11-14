using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spin : MonoBehaviour
{
    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    Animator anim;

    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void SpinProcess()
    {

        RectTransform[] temp = this.GetComponentsInChildren<RectTransform>();
        foreach (var item in temp)
        {
            ChangeSprite(item);
        }

    }

    Sprite ChangeSprite(Transform a)
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        a.GetComponent<Image>().sprite = spriteSource[imageIndex];

        return spriteSource[imageIndex];
    }
}

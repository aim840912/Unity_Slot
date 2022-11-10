using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    // [SerializeField] int rollingSpeed = 250;

    Animator anim;

    [SerializeField] bool SpinBool = false;

    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpinBool = !SpinBool;
        }


        anim.SetBool("Rolling", !SpinBool);

    }

    void SpinProcess()
    {
        RectTransform[] temp = this.GetComponentsInChildren<RectTransform>();
        foreach (var item in temp)
        {
            ChangeSprite(item);
        }
    }

    void SpinOver()
    {

    }

    Sprite ChangeSprite(Transform a)
    {

        int imageIndex = Random.Range(0, spriteSource.Length);
        a.GetComponent<Image>().sprite = spriteSource[imageIndex];

        return spriteSource[imageIndex];
    }
}

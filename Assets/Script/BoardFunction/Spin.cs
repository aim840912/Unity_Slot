using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    [SerializeField] RectTransform[] pos;

    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    [SerializeField] int rollingSpeed = 250;

    [SerializeField] bool rolling = false;

    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }

    void Update()
    {
        if (rolling)
        {
            for (var i = 0; i < 2; i++)
            {
                if (pos[i].localPosition.y > -100)
                {
                    pos[i].Translate(new Vector2(0, -1) * Time.smoothDeltaTime * rollingSpeed);
                }
            }

            if (pos[0].localPosition.y <= -100)
            {
                ChangeSprite(pos[0]);
                pos[0].localPosition = new Vector2(0, pos[1].localPosition.y + 100);
            }

            if (pos[1].localPosition.y <= -100)
            {
                ChangeSprite(pos[1]);
                pos[1].localPosition = new Vector2(0, pos[0].localPosition.y + 100);
            }
        }
        else
        {
            for (var i = 0; i < 2; i++)
            {
                if (pos[i].localPosition.y >= 0)
                {
                    pos[i].localPosition = Vector3.MoveTowards(pos[i].localPosition, new Vector3(0, 0, 0), Time.deltaTime * rollingSpeed);
                }
                else
                {
                    pos[i].localPosition = Vector3.MoveTowards(pos[i].localPosition, new Vector3(0, -100, 0), Time.deltaTime * rollingSpeed);
                }
            }
        }
    }

    Sprite ChangeSprite(Transform a)
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        a.GetComponent<Image>().sprite = spriteSource[imageIndex];

        return spriteSource[imageIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    public Image spinImage;
    public float endPoint;
    public float speed;

    Sequence sequence;
    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }
    void Start()
    {
        DOTween.Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Queue();
        }
    }
    Tween SpinDown()
    {
        // Tweener tweener = this.transform.DOLocalMoveY(this.transform.localPosition.y - 100, speed, false);
        Debug.Log("down");
        return this.transform.DOLocalMoveY(endPoint, speed, true).SetEase(Ease.Linear);
    }
    Tween SpinToOrigin()
    {
        // Tweener tweener = this.transform.DOLocalMoveY(this.transform.localPosition.y - 100, speed, false);
        return this.transform.DOLocalMoveY(110, 0, true).SetEase(Ease.Linear);
    }

    void Queue()
    {

        sequence = DOTween.Sequence();
        // Tween firstTween = SpinDown();
        sequence
        .Append(SpinToOrigin())
        .Append(SpinDown())
        .AppendCallback(ChangeSprite);

        sequence.SetLoops(-1, LoopType.Restart);
    }

    void ChangeSprite()
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        spinImage.sprite = spriteSource[imageIndex];
    }


}

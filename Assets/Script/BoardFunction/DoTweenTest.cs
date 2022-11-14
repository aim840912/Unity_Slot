using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    public RectTransform spinImage;

    public float endPoint;
    public float speed;

    Sequence sequence;
    void Start()
    {
        DOTween.Init();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpinDown();
        }
    }
    Tween SpinDown()
    {
        // Tweener tweener = this.transform.DOLocalMoveY(this.transform.localPosition.y - 100, speed, false);
        return this.transform.DOLocalMoveY(endPoint, speed, true).SetEase(Ease.Linear).OnComplete(Queue);
    }
    Tween SpinToOrigin()
    {
        // Tweener tweener = this.transform.DOLocalMoveY(this.transform.localPosition.y - 100, speed, false);
        return this.transform.DOLocalMoveY(110, 0, true).SetEase(Ease.Linear);
    }
    void doNothing()
    {
        Debug.Log("nothing");
    }

    void Queue()
    {
        sequence = DOTween.Sequence();
        // Tween firstTween = SpinDown();
        sequence
        .Append(SpinToOrigin())
        .Append(SpinDown());


        sequence.SetLoops(-1, LoopType.Restart);
    }


}

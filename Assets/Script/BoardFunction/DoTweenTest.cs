using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    public Image spinImage;
    public RectTransform item;

    public float endPoint;
    float speed;
    public enum SpinType
    {
        motionless,
        Spinning,
        Ending,
    }
    private SpinType spinType = SpinType.motionless;
    Sequence SpinSequence;
    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }

    public void SpinTypeSwitch(SpinType type, TweenCallback callBack)
    {
        if (SpinSequence != null)
        {
            SpinSequence.Kill();
        }

        switch (spinType)
        {
            case SpinType.motionless:
                spinType = SpinType.Spinning;
                SpinDown().OnComplete(SpinLoop);
                break;
            case SpinType.Spinning:
                spinType = SpinType.motionless;

                SpinToStop(callBack);
                break;
            default:
                break;
        }

    }
    Tween SpinDown()
    {
        speed = Random.Range(.2f, .25f);
        return item.transform.DOLocalMoveY(endPoint, speed, true).SetEase(Ease.Linear);
    }
    Tween SpinToOrigin()
    {
        return item.transform.DOLocalMoveY(100, 0, true).SetEase(Ease.Linear);
    }

    void SpinLoop()
    {
        SpinSequence = DOTween.Sequence();
        SpinSequence
        .Append(SpinToOrigin())
        .Append(SpinDown())
        .AppendCallback(RandomChangeSprite);

        SpinSequence.SetLoops(-1, LoopType.Restart);
    }

    void SpinToStop(TweenCallback callBack)
    {
        SpinSequence = DOTween.Sequence();
        SpinSequence
        .Append(SpinDown())
        .Append(SpinToOrigin())
        .AppendCallback(callBack)
        .Append(item.transform.DOLocalMoveY(0, 1.5f, true).SetEase(Ease.OutBack));


    }

    void RandomChangeSprite()
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        spinImage.sprite = spriteSource[imageIndex];
    }
}

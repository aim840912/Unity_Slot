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
    public float speed;
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

    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log(spinType);
    }

    public void SpinTypeSwitch(SpinType type)
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

                SpinDown().OnComplete(SpinToStop);
                break;
            default:
                break;
        }

    }
    Tween SpinDown()
    {
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

    void SpinToStop()
    {
        SpinSequence = DOTween.Sequence();
        SpinSequence
        .Append(SpinToOrigin())
        .Append(item.transform.DOLocalMoveY(0, speed, true));
    }

    void RandomChangeSprite()
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        spinImage.overrideSprite = spriteSource[imageIndex];
    }
}

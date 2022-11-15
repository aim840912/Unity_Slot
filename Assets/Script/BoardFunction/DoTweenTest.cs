using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] Sprite[] spriteSource = new Sprite[10];

    public Image spinImage;

    public RectTransform[] items;
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
    void Awake()
    {
        string path = "Art";
        spriteSource = Resources.LoadAll<Sprite>(path);
    }
    void Start()
    {
        DOTween.Init();
    }

    public void SetupButton()
    {
        if (spinType == SpinType.motionless)
        {
            spinType = SpinType.Spinning;
            SpinDown().OnComplete(SpinLoop);

        }
        else if (spinType == SpinType.Spinning)
        {
            spinType = SpinType.motionless;
            DOTween.Clear();
            SpinDown().OnComplete(SpinToStop);
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
        Sequence LoopSpinSequence;

        LoopSpinSequence = DOTween.Sequence();
        // Tween firstTween = SpinDown();
        LoopSpinSequence
        .Append(SpinToOrigin())
        .Append(SpinDown())
        .AppendCallback(ChangeSprite);


        LoopSpinSequence.SetLoops(-1, LoopType.Restart);
    }

    void SpinToStop()
    {
        Sequence LoopToStopSequence;

        LoopToStopSequence = DOTween.Sequence();
        // Tween firstTween = SpinDown();
        LoopToStopSequence
        .Append(SpinDown())
        .Append(SpinToOrigin())
        .Append(item.transform.DOLocalMoveY(0, speed, true));

    }

    void ChangeSprite()
    {
        int imageIndex = Random.Range(0, spriteSource.Length);
        spinImage.overrideSprite = spriteSource[imageIndex];
    }
}

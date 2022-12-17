using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpinHandlerTest : BaseAction
{
    Sprite[] _spriteSource;
    [SerializeField] Image[] _imageItem;
    [SerializeField] Data _imageData;

    public float EndPoint { get; set; }
    public float StartPoint { get; set; }
    public float Duration
    {
        get { return Random.Range(.2f, .5f); }
    }
    public enum SpinType { motionless, Spinning }

    protected override void Awake()
    {
        base.Awake();
        var _imageHeight = _imageItem[0].rectTransform.rect.size.y;

        StartPoint = _imageHeight;
        EndPoint = _imageHeight * -1f;
    }

    void Start()
    {
        GetSprite();
        FinalImage(BoardNum);
    }

    public override void SpinEvent(int[] boardNum, bool isSpin)
    {
        if (isSpin)
        {
            SetType(SpinType.Spinning, boardNum);
        }
        else
        {
            SetType(SpinType.motionless, boardNum);
        }
    }

    void GetSprite()
    {
        _spriteSource = _imageData.RollingImage;
    }

    public void SetType(SpinType spinType, int[] boardNum)
    {
        DOTween.Clear();
        switch (spinType)
        {
            case SpinType.Spinning:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    StartSpinToLoop(_imageItem[i]);
                }
                break;
            case SpinType.motionless:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    LoopToStop(_imageItem[i], boardNum).Play();
                }
                break;
        }
    }
    Tween StartSpinToLoop(Image item)
    {
        return item.transform.DOLocalMoveY(EndPoint, Duration, true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => SpinLoop(item));
    }
    void SpinLoop(Image item)
    {
        item.transform.localPosition = new Vector3(0, StartPoint, 0);
        item.transform.DOLocalMoveY(EndPoint, Duration, true).SetEase(Ease.Linear).SetLoops(-1).OnStepComplete(() => ChangeSprite(item));
    }

    Tween LoopToStop(Image item, int[] boardNum)
    {
        return item.transform.DOLocalMoveY(EndPoint, Duration, true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Stop(item, boardNum));
    }

    void Stop(Image item, int[] boardNum)
    {
        item.transform.DOLocalMoveY(StartPoint, 0, true).OnComplete(() => FinalImage(boardNum));

        item.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack);
    }

    void ChangeSprite(Image item)
    {
        int imageIndex = Random.Range(0, _spriteSource.Length);
        item.sprite = _spriteSource[imageIndex];
    }

    void FinalImage(int[] boardNum)
    {
        for (int i = 0; i < _imageItem.Length; i++)
        {
            _imageItem[i].sprite = _imageData.RollingImage[boardNum[i]];
        }
    }
}

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
    private SpinType _spinType;

    void Awake()
    {
        var _imageHeight = _imageItem[0].rectTransform.rect.size.y;

        StartPoint = _imageHeight;
        EndPoint = _imageHeight * -1f;
    }

    void Start()
    {
        GetAllSprite();
        FinalImage();
    }

    public override void SpinEvent()
    {
        if (isSpin)
        {
            SetType(SpinType.Spinning);
        }
        else
        {
            SetType(SpinType.motionless);
        }
    }

    void GetAllSprite()
    {
        _spriteSource = _imageData.RollingImage;
    }

    public void SetType(SpinType spinType)
    {
        DOTween.Clear();
        switch (spinType)
        {
            case SpinType.motionless:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    StartSpinToLoop(_imageItem[i]);
                }
                break;
            case SpinType.Spinning:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    LoopToStop(_imageItem[i]).Play();
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

    Tween LoopToStop(Image item)
    {
        return item.transform.DOLocalMoveY(EndPoint, Duration, true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Stop(item));
    }

    void Stop(Image item)
    {
        item.transform.DOLocalMoveY(StartPoint, 0, true).OnComplete(FinalImage);

        item.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack);
    }

    void ChangeSprite(Image item)
    {
        int imageIndex = Random.Range(0, _spriteSource.Length);
        item.sprite = _spriteSource[imageIndex];
    }

    void FinalImage()
    {
        for (int i = 0; i < _imageItem.Length; i++)
        {
            _imageItem[i].sprite = _imageData.RollingImage[BoardNum[i]];
        }
    }
}

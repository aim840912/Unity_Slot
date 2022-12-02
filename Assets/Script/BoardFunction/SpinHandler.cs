using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
/*
    測試 另一種做法
*/
public class SpinHandler : MonoBehaviour
{
    [SerializeField] Image _item;
    [SerializeField] Data _imageData;

    public float EndPoint { get; set; }
    public float StartPoint { get; set; }
    public float Duration
    {
        get { return Random.Range(.2f, .5f); }
    }
    public enum SpinType
    {
        motionless,
        Spinning
    }
    private SpinType _spinType = SpinType.motionless;
    Sequence _spinSequence;
    void Awake()
    {
        var _imageHeight = _item.rectTransform.rect.size.y;
        StartPoint = _imageHeight;
        EndPoint = _imageHeight * -1f;
    }

    public void SetType(SpinType type, TweenCallback callBack)
    {
        ResetSequence();
        switch (_spinType)
        {
            case SpinType.motionless:
                _spinType = SpinType.Spinning;
                SpinDown().OnStepComplete(SpinLoop);
                break;
            case SpinType.Spinning:
                _spinType = SpinType.motionless;
                SpinToStop(callBack);
                break;
        }
    }
    Tween SpinDown()
    {
        return _item.transform.DOLocalMoveY(EndPoint, Duration, true).SetEase(Ease.Linear);
    }
    Tween SpinToOrigin()
    {
        return _item.transform.DOLocalMoveY(StartPoint, 0, true).SetEase(Ease.Linear);
    }

    void SpinLoop()
    {
        _spinSequence = DOTween.Sequence()
        .Append(SpinToOrigin())
        .Append(SpinDown())
        .AppendCallback(ChangeSprite);

        _spinSequence.SetLoops(-1, LoopType.Restart);
    }

    void SpinToStop(TweenCallback callBack)
    {
        _spinSequence = DOTween.Sequence()
        .Append(SpinDown())
        .Append(SpinToOrigin())
        .AppendCallback(callBack)
        .Append(_item.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack));
    }

    void ResetSequence()
    {
        if (_spinSequence != null)
        {
            _spinSequence.Kill();
        }
    }

    void ChangeSprite()
    {
        int imageIndex = Random.Range(0, _imageData.RollingImage.Length);
        _item.sprite = _imageData.RollingImage[imageIndex];
    }
}

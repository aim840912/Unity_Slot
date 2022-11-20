using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class SetSpin : MonoBehaviour
{
    [SerializeField] Sprite[] _spriteSource = new Sprite[10];
    [SerializeField] Image Item;// so bad , 直接拉關聯比較好


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
        var _imageHeight = Item.rectTransform.rect.size.y;
        StartPoint = _imageHeight;
        EndPoint = _imageHeight * -1f;

        GetAllSprite();
    }

    void GetAllSprite()// so bad 做出manager比較好
    {
        string path = "Art";
        _spriteSource = Resources.LoadAll<Sprite>(path);
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
        return Item.transform.DOLocalMoveY(EndPoint, Duration, true).SetEase(Ease.Linear);
    }
    Tween SpinToOrigin()
    {
        return Item.transform.DOLocalMoveY(StartPoint, 0, true).SetEase(Ease.Linear);
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
        .Append(Item.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack));
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
        int imageIndex = Random.Range(0, _spriteSource.Length);
        Item.sprite = _spriteSource[imageIndex];
    }
}

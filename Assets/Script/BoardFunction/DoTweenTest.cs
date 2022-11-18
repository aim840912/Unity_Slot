using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] Sprite[] _spriteSource = new Sprite[10];
    Image Item
    {
        get
        {
            return this.gameObject.transform.GetChild(0).GetComponent<Image>();
        }
    }

    public float EndPoint
    {
        get { return -100; }
    }
    public float StartPoint
    {
        get { return 100; }
    }
    public float Speed
    {
        get { return Random.Range(.2f, .25f); }
    }
    public enum SpinType
    {
        motionless,
        Spinning,
        Ending,
    }
    private SpinType _spinType = SpinType.motionless;
    Sequence _spinSequence;
    void Awake()
    {
        GetAllSprite();
    }

    void GetAllSprite()
    {
        string path = "Art";
        _spriteSource = Resources.LoadAll<Sprite>(path);
    }

    public void SpinTypeSwitch(SpinType type, TweenCallback callBack)
    {
        ResetSequence();
        switch (_spinType)
        {
            case SpinType.motionless:
                _spinType = SpinType.Spinning;
                SpinDown().OnComplete(SpinLoop);
                break;
            case SpinType.Spinning:
                _spinType = SpinType.motionless;
                SpinToStop(callBack);
                break;
        }
    }
    Tween SpinDown()
    {
        return Item.transform.DOLocalMoveY(EndPoint, Speed, true).SetEase(Ease.Linear);
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
        .Append(Item.transform.DOLocalMoveY(0, 1.5f, true).SetEase(Ease.OutBack));
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

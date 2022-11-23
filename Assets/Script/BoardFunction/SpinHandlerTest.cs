using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
/*
    測試用
*/
public class SpinHandlerTest : MonoBehaviour
{

    [SerializeField] Sprite[] _spriteSource = new Sprite[10];
    [SerializeField] Image[] _imageItem;

    [SerializeField] Data _imageData;

    [SerializeField] SlotMachine slotMachine;

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
        var _imageHeight = _imageItem[0].rectTransform.rect.size.y;
        StartPoint = _imageHeight;
        EndPoint = _imageHeight * -1f;
        // DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        GetAllSprite();
    }
    bool _isSpin = false;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _isSpin = !_isSpin;
            if (_isSpin)
            {
                StartSpin();
            }
            else
            {
                StopSpin();
            }
        }
    }

    public void StartSpin()
    {
        this.SetType(SpinType.motionless);
    }

    public void StopSpin()
    {
        this.SetType(SpinType.Spinning);
    }

    void GetAllSprite()
    {
        _spriteSource = _imageData.RollingImage;
    }

    public void SetType(SpinType type)
    {
        DOTween.Clear();
        switch (_spinType)
        {
            case SpinType.motionless:
                _spinType = SpinType.Spinning;
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    StartSpinToLoop(_imageItem[i]);
                }
                break;
            case SpinType.Spinning:
                _spinType = SpinType.motionless;
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
        item.transform.localPosition = new Vector3(0, 100, 0);
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
        // FinalImage();
        // item.transform.localPosition = new Vector3(0, 100, 0);
        // ChangeSprite(item);
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
            _imageItem[i].sprite = _imageData.RollingImage[slotMachine.BoardNum[i]];
        }
    }
}

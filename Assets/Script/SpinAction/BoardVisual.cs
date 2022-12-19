using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoardVisual : BaseSpin
{
    [SerializeField] Image[] _imageItem;
    [SerializeField] Data _imageData;
    int[] _boardNum;
    float _startPoint;
    float _endPoint;

    public float Duration { get { return Random.Range(.2f, .5f); } }
    public enum SpinType { motionless, Spinning }

    void Awake()
    {
        BoardInit();
    }

    void BoardInit()
    {
        _boardNum = SaveManager.LoadBoard().boardNum;
        FinalBoardImage(_boardNum);

        SetSpinHeight();
    }

    void SetSpinHeight()
    {
        float _imageHeight = _imageItem[0].rectTransform.rect.size.y;

        _startPoint = _imageHeight;
        _endPoint = _imageHeight * -1f;
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
            StoreBoardNum(boardNum);
        }
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
                    LoopToStop(_imageItem[i], boardNum[i]).Play();
                }
                break;
        }
    }
    Tween StartSpinToLoop(Image item)
    {
        return item.transform.DOLocalMoveY(_endPoint, Duration, true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => SpinLoop(item));
    }
    void SpinLoop(Image item)
    {
        item.transform.localPosition = new Vector3(0, _startPoint, 0);
        item.transform.DOLocalMoveY(_endPoint, Duration, true).SetEase(Ease.Linear).SetLoops(-1).OnStepComplete(() => ChangeSprite(item));
    }

    Tween LoopToStop(Image item, int boardNum)
    {
        return item.transform.DOLocalMoveY(_endPoint, Duration, true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Stop(item, boardNum));
    }

    void Stop(Image item, int boardNum)
    {
        item.transform.DOLocalMoveY(_startPoint, 0, true).OnComplete(() => FinalImage(item, boardNum));

        item.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack);
    }
    void FinalImage(Image item, int boardNum)
    {
        item.sprite = _imageData.RollingImage[boardNum];
    }

    void ChangeSprite(Image item)
    {
        int imageIndex = Random.Range(0, _imageData.RollingImage.Length);
        item.sprite = _imageData.RollingImage[imageIndex];
    }

    void FinalBoardImage(int[] boardNum)
    {
        for (int i = 0; i < _imageItem.Length; i++)
        {
            _imageItem[i].sprite = _imageData.RollingImage[boardNum[i]];
        }
    }

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}

using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoardVisual : BaseSpin
{
    [SerializeField] Image[] _imageItem;
    [SerializeField] Data _imageData;
    float _startPoint;
    float _endPoint;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        LoadImage();
        SetSpinPoint();
    }


    void LoadImage() // TODO : 想更好的名稱
    {
        int[] _boardNum = SaveManager.LoadBoard().boardNum;

        for (int i = 0; i < _imageItem.Length; i++)
        {
            _imageItem[i].sprite = _imageData.RollingImage[_boardNum[i]];
        }
    }

    void SetSpinPoint()
    {
        float _imageHeight = _imageItem[0].rectTransform.rect.size.y;

        _startPoint = _imageHeight;
        _endPoint = _imageHeight * -1f;
    }

    public override void Spin(int[] boardNum, SpinType spinType)
    {
        if (spinType == SpinType.spin)
        {
            SetType(SpinType.spin, boardNum);
        }
        else
        {
            SetType(SpinType.stop, boardNum);
            StoreBoardNum(boardNum);
        }
    }

    public void SetType(SpinType spinType, int[] boardNum)
    {
        DOTween.Clear();
        switch (spinType)
        {
            case SpinType.spin:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    StartSpinToLoop(_imageItem[i]);
                }
                break;
            case SpinType.stop:
                for (int i = 0; i < _imageItem.Length; i++)
                {
                    LoopToStop(_imageItem[i], boardNum[i]).Play();
                }
                break;
        }
    }
    Tween StartSpinToLoop(Image item)
    {
        return item.transform.DOLocalMoveY(_endPoint, SetDuration(), true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => SpinLoop(item));
    }
    void SpinLoop(Image item)
    {
        item.transform.localPosition = new Vector3(0, _startPoint, 0);
        item.transform.DOLocalMoveY(_endPoint, SetDuration(), true).SetEase(Ease.Linear).SetLoops(-1).OnStepComplete(() => ChangeSprite(item));
    }

    Tween LoopToStop(Image item, int boardNum)
    {
        return item.transform.DOLocalMoveY(_endPoint, SetDuration(), true)
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

    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }

    float SetDuration() // TODO : 想更好的名稱
    {
        return Random.Range(.2f, .5f);
    }
}

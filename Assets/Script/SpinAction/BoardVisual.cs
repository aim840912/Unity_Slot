using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoardVisual : BaseSpin
{
    [SerializeField] Image[] _images;
    [SerializeField] Data _imageData;
    float _topPoint;
    float _bottomPoint;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        LoadSprite();
        SetPoint();
    }

    void LoadSprite() // TODO : 想更好的名稱
    {
        int[] _boardNum = SaveManager.LoadBoard().boardNum;

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _imageData.RollingImage[_boardNum[i]];
        }
    }

    void SetPoint()
    {
        float _imageHeight = _images[0].rectTransform.rect.size.y;

        _topPoint = _imageHeight;
        _bottomPoint = _imageHeight * -1f;
    }

    public override void Spin(SpinType spinType)
    {
        if (spinType == SpinType.spin)
        {
            SetSpin(SpinType.spin);
        }
        else
        {
            SetSpin(SpinType.stop);
            StoreBoardNum(BoardNum);
        }
    }

    public void SetSpin(SpinType spinType)
    {
        DOTween.Clear();
        switch (spinType)
        {
            case SpinType.spin:
                for (int i = 0; i < _images.Length; i++)
                {
                    StartLoop(_images[i]);
                }
                break;
            case SpinType.stop:
                for (int i = 0; i < _images.Length; i++)
                {
                    LoopStop(_images[i], BoardNum[i]).Play();
                }
                break;
        }
    }

    #region Start Spin
    Tween StartLoop(Image eachImage)
    {
        return eachImage.transform.DOLocalMoveY(_bottomPoint, SetDuration(), true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => Loop(eachImage));
    }
    void Loop(Image eachImage)
    {
        eachImage.transform.localPosition = new Vector3(0, _topPoint, 0);
        eachImage.transform.DOLocalMoveY(_bottomPoint, SetDuration(), true).SetEase(Ease.Linear).SetLoops(-1).OnStepComplete(() => ChangeSprite(eachImage));
    }
    void ChangeSprite(Image item)
    {
        int imageIndex = Random.Range(0, _imageData.RollingImage.Length);
        item.sprite = _imageData.RollingImage[imageIndex];
    }

    #endregion

    #region Stop Spin
    Tween LoopStop(Image eachImage, int boardNum)
    {
        return eachImage.transform.DOLocalMoveY(_bottomPoint, SetDuration(), true)
        .SetEase(Ease.Linear)
        .OnComplete(() => TopPointToOriginPoint(eachImage, boardNum));
    }

    void TopPointToOriginPoint(Image eachImage, int boardNum)
    {
        ChangeFinalSprite(eachImage, boardNum);
        eachImage.transform.DOLocalMoveY(0, Random.Range(1, 1.5f), true).SetEase(Ease.OutBack);
    }

    void ChangeFinalSprite(Image eachImage, int boardNum)
    {
        eachImage.transform.localPosition = new Vector3(0, 100, 0);
        eachImage.sprite = _imageData.RollingImage[boardNum];
    }

    #endregion
    float SetDuration()
    {
        return Random.Range(.2f, .5f);
    }
    void StoreBoardNum(int[] boardNum)
    {
        SaveManager.CurrentBoardSaveData.boardNum = boardNum;
        SaveManager.SaveBoard();
    }
}
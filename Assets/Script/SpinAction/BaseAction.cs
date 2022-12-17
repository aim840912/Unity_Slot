using UnityEngine;
public abstract class BaseAction : MonoBehaviour
{
    public abstract void SpinEvent(int[] boardNum, bool isSpin);
    public int[] BoardNum { get; set; }

    protected virtual void Awake()
    {
        BoardNum = SaveManager.LoadBoard().boardNum;
    }
}

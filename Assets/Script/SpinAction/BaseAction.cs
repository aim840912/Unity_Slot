using UnityEngine;
public abstract class BaseAction : MonoBehaviour
{
    public abstract void SpinEvent(int[] boardNum, bool isSpin);
    protected int[] BoardNum { get; set; }
}

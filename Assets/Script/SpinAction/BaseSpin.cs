using UnityEngine;
public abstract class BaseSpin : MonoBehaviour
{
    public abstract void SpinEvent(int[] boardNum, SpinType spinType);

    public enum SpinType { motionless, Spinning }
}

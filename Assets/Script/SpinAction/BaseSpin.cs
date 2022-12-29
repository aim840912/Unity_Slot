using UnityEngine;
public abstract class BaseSpin : MonoBehaviour
{
    public abstract void Spin(int[] boardNum, SpinType spinType);

    public enum SpinType { stop, spin }

}

using UnityEngine;
public abstract class BaseSpin : MonoBehaviour
{
    public abstract void Spin(SpinType spinType);

    public enum SpinType { stop, spin }

    public int[] BoardNum { get; set; }
}

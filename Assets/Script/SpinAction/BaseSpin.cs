using UnityEngine;
public abstract class BaseSpin : MonoBehaviour
{
    public abstract void Spin();
    public abstract void Stop();
    public int[] BoardNum { get; set; }
}

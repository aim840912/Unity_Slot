using UnityEngine;

[CreateAssetMenu(fileName = "Line Data", menuName = "Line/Create Line Data Asset", order = 3)]
public class LineData : ScriptableObject
{
    public Line[] Lines;
}

[System.Serializable]
public struct Line
{
    public LineRenderer LineRenderer;
    public int[] IndexLine;
}

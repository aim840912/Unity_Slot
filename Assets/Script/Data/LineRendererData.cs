using UnityEngine;

[CreateAssetMenu(fileName = "LineRenderer Data", menuName = "SlotMachine/Create Line Renderer Data Asset", order = 3)]
public class LineRendererData : ScriptableObject
{
    public LineObj[] LineObjs;
}

[System.Serializable]
public struct LineObj
{
    public LineRenderer LineRenderer;
    public int[] IndexLine;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LineRenderer Data", menuName = "SlotMachine/Create Line Renderer Data Asset", order = 3)]
public class LineRendererData : ScriptableObject
{
    public LineRender[] LineRender;
}

[System.Serializable]
public struct LineRender
{
    public LineRenderer LineRenderer;
    public int[] IndexLine;
}

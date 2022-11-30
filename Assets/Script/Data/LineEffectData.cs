using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LineEffect Data", menuName = "SlotMachine/Create Line Data Asset", order = 2)]
public class LineEffectData : ScriptableObject
{
    public Line[] Line;
}

[System.Serializable]
public struct Line
{
    public Image LineImage;
    public int[] IndexLine;

}

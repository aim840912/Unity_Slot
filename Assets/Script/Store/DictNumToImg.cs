using System.Collections.Generic;
using UnityEngine;

public class DictNumToImg
{
    public static Dictionary<int, Sprite> numToImg = new Dictionary<int, Sprite>()
    {
        { 0, Resources.Load<Sprite>("Art/gura") },
        { 1, Resources.Load<Sprite>("Art/ame") },
        { 2, Resources.Load<Sprite>("Art/ina") },
        { 3, Resources.Load<Sprite>("Art/kronii") },
        { 4, Resources.Load<Sprite>("Art/mumei") },
        { 5, Resources.Load<Sprite>("Art/sana") },
        { 6, Resources.Load<Sprite>("Art/bae") },
        { 7, Resources.Load<Sprite>("Art/fauna") },
        { 8, Resources.Load<Sprite>("Art/irys") },
        { 9, Resources.Load<Sprite>("Art/hololive") },
    };

}

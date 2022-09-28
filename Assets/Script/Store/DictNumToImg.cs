using System.Collections.Generic;
using UnityEngine;

public class DictNumToImg
{
    static Sprite gura = Resources.Load<Sprite>("Art/gura");
    static Sprite ame = Resources.Load<Sprite>("Art/ame");
    static Sprite ina = Resources.Load<Sprite>("Art/ina");
    static Sprite kronii = Resources.Load<Sprite>("Art/kronii");
    static Sprite mumei = Resources.Load<Sprite>("Art/mumei");
    static Sprite sana = Resources.Load<Sprite>("Art/sana");
    static Sprite bae = Resources.Load<Sprite>("Art/bae");
    static Sprite fauna = Resources.Load<Sprite>("Art/fauna");
    static Sprite irys = Resources.Load<Sprite>("Art/irys");
    static Sprite hololive = Resources.Load<Sprite>("Art/hololive");

    public static readonly Dictionary<int, Sprite> numToImg = new Dictionary<int, Sprite>()
    {
        { 0, gura },
        { 1, ame },
        { 2, ina },
        { 3, kronii },
        { 4, mumei },
        { 5, sana },
        { 6, bae },
        { 7, fauna },
        { 8, irys },
        { 9, hololive },
    };

}

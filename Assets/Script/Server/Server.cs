using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Server
{
    public abstract int[] GenerateNum();

    public abstract int GetFinalMoney(int betMoney, out int odds);
}

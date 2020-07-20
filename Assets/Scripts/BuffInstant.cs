using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffInstant : Buff
{
    public BuffInstant()
    {
        duration = 0;
        stacks = 1;
        name = "instant";
    }

    public override void TriggeredUpdate()
    {
        target.RemoveBuff(this);
        Execute();
    }

    public abstract void Execute();
}

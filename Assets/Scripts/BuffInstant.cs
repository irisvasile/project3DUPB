using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffInstant : Buff
{
    public BuffInstant()
    {
        durationMax = -1;
        stacksMax = 1;
        name = "instant";
    }
    public override void OnApply(Unit target)
    {
        target.RemoveBuff(this);
        Execute(target);
    }

    public override void TriggeredUpdate(Unit target)
    {
    }

    public abstract void Execute(Unit target);
}

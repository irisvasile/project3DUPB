using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffInstant : Buff
{
    public Buff effect;
    public BuffInstant()
    {
        durationMax = -1;
        stacksMax = 1;
        name = "instant";
    }
    public override void OnApply(Unit target)
    {
        if (effect != null)
            target.ApplyBuff(effect, target.buffSources[this]);
        target.RemoveBuff(this);
        Execute(target);
    }

    public override void TriggeredUpdate(Unit target)
    {
    }

    public abstract void Execute(Unit target);
}

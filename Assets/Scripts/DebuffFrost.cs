using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffFrost : Buff
{
    public float movementSlow, attackSlow;

    public DebuffFrost(string name, float durationMax, int stacksMax, float movementSlow, float attackSlow)
    {
        this.name = name;
        this.durationMax = durationMax;
        this.stacksMax = stacksMax;
    }

    public override void OnApply(Unit target)
    {
    }

    public override void TriggeredUpdate(Unit target)
    {
        if (target == null)
            return;
    }
}

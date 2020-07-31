using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffStun : Buff
{
    public DebuffStun(string name, float durationMax)
    {
        this.name = name;
        this.durationMax = durationMax;
        stacksMax = 1;
    }

    public override void OnApply(Unit target)
    {

    }

    public override void TriggeredUpdate(Unit target)
    {
        target.isStunned = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffStun : Buff
{
    public DebuffStun(string buffName, float durationMax)
    {
        this.buffName = buffName;
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

    protected override void GenerateMainDescription()
    {
        description = "Target can't move, attack or use spells.";
    }
}

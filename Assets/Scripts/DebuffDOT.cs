using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDOT : Buff
{
    public float t = 0, damageInterval = 1, damageOverTime = 5, initialDamage = 0;

    public DebuffDOT(string buffName, float durationMax, int stacksMax, float damageInterval, float damageOverTime, string impactName)
    {
        this.buffName = buffName;
        this.durationMax = durationMax;
        this.stacksMax = stacksMax;
        this.damageInterval = damageInterval;
        this.damageOverTime = damageOverTime;
        LoadImpact(impactName);
    }

    public override void TriggeredUpdate(Unit target)
    {
        if (target == null)
            return;
        t += Time.deltaTime;
        if (t >= damageInterval)
        {
            t -= damageInterval;
            target.TakeDamage(damageOverTime * target.buffStacks[this]);
            ShowImpact(target);
        }
    }
}

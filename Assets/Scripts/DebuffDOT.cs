using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDOT : Buff
{
    public float damageInterval = 1, damageOverTime = 5;

    public DebuffDOT(string buffName, float durationMax, int stacksMax, float damageInterval, float damageOverTime, string impactName)
    {
        this.buffName = buffName;
        this.durationMax = durationMax + 0.1f; //daca pun fara 0.1f, efectul din ultima secunda nu se execta
        this.stacksMax = stacksMax;
        this.damageInterval = damageInterval;
        this.damageOverTime = damageOverTime;
        LoadImpact(impactName);
    }

    public override void TriggeredUpdate(Unit target)
    {
        if (target == null)
            return;
        target.buffTimer[this] += Time.deltaTime;
        if (target.buffTimer[this] >= damageInterval)
        {
            target.buffTimer[this] -= damageInterval;
            target.TakeDamage(damageOverTime * target.buffStacks[this]);
            ShowImpact(target);
        }
    }
    protected override void GenerateMainDescription()
    {
        description = "Deals " + damageOverTime + " damage every ";
        if (damageInterval == 1)
            description += "second.";
        else
            description += damageInterval + " seconds.";
    }
}

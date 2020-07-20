using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDOT : Buff
{
    public float t = 0, damageInterval = 1, damage = 5;

    public DebuffDOT(string name, float duration, int stacksMax, float damageInterval, float damage)
    {
        this.name = name;
        this.duration = duration;
        this.stacksMax = stacksMax;
        this.damageInterval = damageInterval;
        this.damage = damage;
    }

    public override void TriggeredUpdate()
    {
        if (target == null)
            return;
        t += Time.deltaTime;
        if (t >= damageInterval)
        {
            t -= damageInterval;
            target.TakeDamage(damage);
        }
    }
}

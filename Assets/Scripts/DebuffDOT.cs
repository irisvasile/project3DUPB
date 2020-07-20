using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDOT : Buff
{
    public float t = 0, damageInterval = 1, damage = 5;

    public DebuffDOT()
    {
        duration = 10;
        stacksMax = 1;
        name = "fire";
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

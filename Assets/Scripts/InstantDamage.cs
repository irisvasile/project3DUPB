using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDamage : BuffInstant
{
    public float damage;

    public InstantDamage(float damage, Buff nextBuff)
    {
        this.damage = damage;
        this.nextBuff = nextBuff;
    }

    public override void Execute(Unit target)
    {
        target.TakeDamage(damage);
    }

    protected override void GenerateMainDescription()
    {
        description = "Deals " + damage + " damage";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDamage : BuffInstant
{
    public float damage;

    public InstantDamage(float damage)
    {
        this.damage = damage;
    }

    public override void Execute(Unit target)
    {
        target.TakeDamage(damage);
    }
}

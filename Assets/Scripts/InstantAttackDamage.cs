using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAttackDamage : BuffInstant
{
    public float damageAmplifier;

    public InstantAttackDamage(float damageAmplifier)
    {
        this.damageAmplifier = damageAmplifier;
    }

    public override void Execute(Unit target)
    {
        target.TakeDamage(damageAmplifier * target.buffSources[this].GetAttackDamage());
    }
}

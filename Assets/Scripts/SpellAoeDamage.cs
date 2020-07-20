using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAoeDamage : Spell
{
    public SpellAoeDamage(string spellName, float cooldownMax, float manaCost, float damage, float radius)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        range = -1;
        this.damage = damage;
        this.radius = radius;
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        //pentru ca e aoe in jurul casterului, pos nu este folosit
        Collider[] hitColliders = Physics.OverlapSphere(user.transform.position, radius);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && user.IsEnemy(u))
            {
                u.TakeDamage(damage);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBlink : Spell
{
    public SpellBlink(string spellName, float cooldownMax, float manaCost, float range, float damage, float radius)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        this.range = range;
        this.damage = damage;
        this.radius = radius;
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
        user.transform.position = pos;
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

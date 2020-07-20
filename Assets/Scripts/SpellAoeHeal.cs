using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAoeHeal : Spell
{
    public SpellAoeHeal(string spellName, float cooldownMax, float manaCost, float range, float healing, float radius)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        range = -1;
        damage = healing;
        this.radius = radius;
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(user.transform.position, radius);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && !user.IsEnemy(u))
            {
                u.Heal(damage);
            }
        }
    }
}

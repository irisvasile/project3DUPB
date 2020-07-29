using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellExplosion : Spell
{
    public SpellExplosion(string spellName, float cooldownMax, float manaCost, float range, Buff effect, float radius, bool targetsEnemies, bool targetsSelf, string impactName)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        this.range = range;
        this.effect = effect;
        this.radius = radius;
        this.targetsEnemies = targetsEnemies;
        this.targetsSelf = targetsSelf;
        LoadImpact(impactName);
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
        ShowImpact(pos);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && user.CanTarget(u, targetsEnemies, targetsSelf))
            {
                u.ApplyBuff(effect, user);
            }
        }
    }
}

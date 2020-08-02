using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAoe : Spell
{
    public SpellAoe(string spellName, float cooldownMax, float manaCost, Buff effect, float radius, bool targetsEnemies, bool targetsSelf, string impactName)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        range = int.MaxValue;
        this.effect = effect;
        this.radius = radius;
        this.targetsEnemies = targetsEnemies;
        this.targetsSelf = targetsSelf;
        this.impactName = impactName;
        LoadImpact(impactName);
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(user.transform.position, radius);
        ShowImpact(user.transform.position);
        if (radius == 0 || targetsSelf)
            user.ApplyBuff(effect, user);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && user.CanTarget(u, targetsEnemies, false))
            {
                u.ApplyBuff(effect, user);
            }
        }
    }

    public override Spell Clone()
    {
        return new SpellAoe(spellName, cooldownMax, manaCost, effect, radius, targetsEnemies, targetsSelf, impactName);
    }

    protected override void GenerateMainDescription()
    {
        if (radius == 0)
            description = "Apply buffs to yourself.";
        else
        {
            if (targetsEnemies)
                description = "Apply buffs to nearby enemies";
            else
                description = "Apply buffs to nearby allies";
            if (targetsSelf)
                description += " and yourself.";
            else
                description += ".";
        }
    }
}

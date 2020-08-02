using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellExplosion : Spell
{
    public bool isBlink;

    public SpellExplosion(string spellName, float cooldownMax, float manaCost, float range, Buff effect, float radius, bool targetsEnemies, bool targetsSelf, string impactName, bool isBlink)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        this.range = range;
        this.effect = effect;
        this.radius = radius;
        this.targetsEnemies = targetsEnemies;
        this.targetsSelf = targetsSelf;
        this.impactName = impactName;
        LoadImpact(impactName);
        this.isBlink = isBlink;
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        if (isBlink)
            user.transform.position = pos;
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

    public override Spell Clone()
    {
        return new SpellExplosion(spellName, cooldownMax, manaCost, range, effect, radius, targetsEnemies, targetsSelf, impactName, isBlink);

    }

    protected override void GenerateMainDescription()
    {
        if (isBlink)
            description = "Teleport up to " + range + " units away and apply";
        else
            description = "Apply";
        if (targetsEnemies)
            description += " buffs to enemies in a radius around the target.";
        else
            description += " buffs to allies in a radius around the target.";
        if (targetsSelf)
        {
            description += " The buffs are also applied to you";
            if (!isBlink)
                description += ".";
            else
                description += " if you are within the radius of the target.";
        }
    }
}

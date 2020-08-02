using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMissile : Spell
{
    public float speed;
    public string missileName;

    public SpellMissile(string spellName, float cooldownMax, float manaCost, float range, Buff effect, float radius, float speed, bool targetsEnemies, string missileName, string impactName)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        this.range = range;
        this.effect = effect;
        this.radius = radius;
        this.speed = speed;
        this.targetsEnemies = targetsEnemies;
        this.missileName = missileName;
        this.impactName = impactName;
        LoadImpact(impactName);
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Missile.Summon(missileName, impactType, this, user, pos);
    }

    public override Spell Clone()
    {
        return new SpellMissile(spellName, cooldownMax, manaCost, range, effect, radius, speed, targetsEnemies, missileName, impactName);
    }

    protected override void GenerateMainDescription()
    {
        description = "Fire a missile that explodes on contact and applies buffs to all";
        if (targetsEnemies)
            description +=  " enemies inside the explosion.";
        else
            description += " allies inside the explosion.";
    }
}

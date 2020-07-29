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
        LoadImpact(impactName);
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Missile.Summon(missileName, impactType, this, user, pos);
    }
}

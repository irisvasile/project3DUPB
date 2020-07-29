using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SpellBlink : Spell
{
    public SpellBlink(string spellName, float cooldownMax, float manaCost, float range, Buff effect, float radius, bool targetsEnemies, bool targetsSelf, string impactName)
    {
        this.spellName = spellName;
        this.cooldownMax = cooldownMax;
        this.manaCost = manaCost;
        this.range = range;
        this.effect = effect;
        this.radius = radius;
        this.targetsEnemies = targetsEnemies;
        this.targetsSelf = targetsSelf;
        impactType = Resources.Load<ParticleSystem>("Prefabs/Impacts/" + impactName) as ParticleSystem;
    }

    public override void Use(ManaUser user, Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
        if (impactType != null)
        {
            ParticleSystem impact = GameObject.Instantiate(impactType) as ParticleSystem;
            ShapeModule sm = impact.shape;
            sm.radius = radius;
            impact.transform.position = pos + Vector3.up;
        }
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && user.CanTarget(u, targetsEnemies, targetsSelf))
            {
                u.ApplyBuff(effect, user);
            }
        }
        user.transform.position = pos;
    }
}

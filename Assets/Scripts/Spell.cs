using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Spell
{
    public string spellName;
    public float manaCost = 0, range, damage, radius;
    public float cooldownMax, cooldown = 0;
    public Buff effect;
    public bool targetsEnemies;
    public bool targetsSelf;
    public string impactName;
    public ParticleSystem impactType;
    protected string description = "";

    public bool Cast(ManaUser user, Vector3 pos)
    {
        if (cooldown > 0)
        {
            //Debug.Log(spellName + " not ready yet! CD Remaining: " + cooldown);
            return false;
        }
        if (Vector3.Distance(user.transform.position, pos) > range)
        {
            //Debug.Log("Too far away!");
            return false;
        }
        if (user.SpendMana(manaCost))
        {
            cooldown = cooldownMax;
            Use(user, pos);
            //Debug.Log("Casted!");
            return true;
        }
        //Debug.Log("Not enough mana!");
        return false;
    }

    public void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
            cooldown = 0;
    }

    public void ShowImpact(Vector3 pos)
    {
        if (impactType != null)
        {
            ParticleSystem impact = GameObject.Instantiate(impactType) as ParticleSystem;
            //ShapeModule sm = impact.shape;
            //sm.radius = radius;
            impact.transform.localScale *= radius;
            impact.transform.position = pos + Vector3.up;
        }
    }

    public void LoadImpact(string impactName)
    {
        impactType = Resources.Load<ParticleSystem>("Prefabs/Impacts/" + impactName) as ParticleSystem;
    }

    public abstract void Use(ManaUser user, Vector3 pos);
    public abstract Spell Clone();

    public string GetDescription()
    {
        if (description.Equals(""))
        {
            GenerateMainDescription();
            Buff b = effect;
            if (b != null)
            {
                description += "\nApplied buffs:";
            }
            while (b != null)
            {
                if (!(b is BuffInstant))
                    description += "\n" + b.buffName + ":";
                description += "\n" + b.GetDescription();
                b = b.nextBuff;
            }
        }
        return description;
    }

    protected abstract void GenerateMainDescription();
}
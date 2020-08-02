using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    public int stacksMax;
    public float durationMax;
    public string buffName = "Default Buff";
    public Buff nextBuff;
    public ParticleSystem impactType;
    protected string description = "";

    public virtual void OnApply(Unit target)
    {
        Debug.LogError(buffName + " applied to " + target.name);

        if (nextBuff != null)
            target.ApplyBuff(nextBuff, target.buffSources[this]);
    }

    public void FixedUpdate(Unit target)
    {
        if (!target || !target.buffSources.ContainsKey(this))
            return;
        TriggeredUpdate(target);
        target.buffDuration[this] -= Time.deltaTime;
        if (target.buffDuration[this] < 0)
        {
            target.RemoveBuff(this);
        }
    }
    public void ShowImpact(Unit target)
    {
        if (impactType != null)
        {
            ParticleSystem impact = GameObject.Instantiate(impactType) as ParticleSystem;
            impact.transform.localScale *= 2;
            impact.transform.position = target.transform.position + 2 * Vector3.up;
        }
    }

    public void LoadImpact(string impactName)
    {
        impactType = Resources.Load<ParticleSystem>("Prefabs/Impacts/" + impactName) as ParticleSystem;
    }

    public virtual void TriggeredUpdate(Unit target)
    {

    }

    public bool Equals(Buff buff)
    {
        if (this is BuffInstant || buff is BuffInstant)
            return false;
        return buffName.Equals(buff.buffName);
    }

    public override int GetHashCode()
    {
        return buffName.GetHashCode();
    }

    public string GetDescription()
    {
        if (description.Equals(""))
        {
            GenerateMainDescription();
            if (!(this is BuffInstant))
            {
                if (stacksMax > 1)
                {
                    description += " Stacks " + stacksMax + " times.";
                }
                description += " Lasts " + Mathf.RoundToInt(durationMax) + " seconds.";
            }
        }
        return description;
    }

    protected abstract void GenerateMainDescription();
}

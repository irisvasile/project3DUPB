using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    public int stacksMax;
    public float durationMax;
    public string name = "buff";

    public virtual void OnApply(Unit target)
    {

    }

    public void FixedUpdate(Unit target)
    {
        if (!target)
            return;
        TriggeredUpdate(target);
        target.buffDuration[this] -= Time.deltaTime;
        if (target.buffDuration[this] < 0)
        {
            target.RemoveBuff(this);
        }
    }

    public virtual void TriggeredUpdate(Unit target)
    {

    }

    public bool Equals(Buff buff)
    {
        return name.Equals(buff.name);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

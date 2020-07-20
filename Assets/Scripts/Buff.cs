using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    public Unit source, target;
    public int stacks = 1, stacksMax;
    public float duration;
    public string name = "buff";

    public void FixedUpdate()
    {
        TriggeredUpdate();
        duration -= Time.deltaTime;
        if (duration < 0)
            target.RemoveBuff(this);
    }

    public abstract void TriggeredUpdate();

    public bool Equals(Buff buff)
    {
        return name.Equals(buff.name);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

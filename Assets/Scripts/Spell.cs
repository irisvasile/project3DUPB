using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string spellName;
    public float manaCost = 0, range, damage, radius;
    public float cooldownMax, cooldown = 0;
    public Buff effect;

    public bool Cast(ManaUser user, Vector3 pos)
    {
        if (cooldown > 0)
        {
            Debug.Log(spellName + " not ready yet! CD Remaining: " + cooldown);
            return false;
        }
        if (range != -1 && Vector3.Distance(user.transform.position, pos) > range)
        {
            Debug.Log("Too far away!");
            return false;
        }
        if (user.SpendMana(manaCost))
        {
            cooldown = cooldownMax;
            Use(user, pos);
            return true;
        }
        Debug.Log("Not enough mana!");
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

    public abstract void Use(ManaUser user, Vector3 pos);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUser : Unit
{
    public float mana = 100, manaMax = 100, regen = 5;
    public List<Spell> spells = new List<Spell>();
    public Spell attackSpell;

    public new void FixedUpdate()
    {
        base.FixedUpdate();
        if (mana < manaMax)
        {
            mana += regen * Time.deltaTime * manaMax / 100;
            if (mana > manaMax)
                mana = manaMax;
        }
        for (int i = 0; i < spells.Count; ++i)
        {
            Spell spell = spells[i];
            spell.FixedUpdate();
            if (spells.Count <= i)
                break;
            if (!spell.Equals(spells[i]))
            {
                --i;
            }
        }
    }

    /**
     * <summary>Adds mana to the unit without overflowing.</summary>
     */
    public void AddMana(float amount)
    {
        mana += amount;
        if (mana > manaMax)
            mana = manaMax;
        else if (mana < 0)
            mana = 0;
    }


    /**
     * <summary>If it has enough mana, will spend it and return true, else it returns false.</summary>
     */
    public bool SpendMana(float amount)
    {
        if (mana < amount)
            return false;
        mana -= amount;
        return true;
    }

    /**
     * <summary>Checks if unit has enough mana for the spell at the given index.</summary>
     */
    public bool HasMana(int index)
    {
        return spells[index].manaCost <= mana;
    }

    /**
     * <summary>Checks if spell at given index is not on cooldown.</summary>
     */
    public bool IsReady(int index)
    {
        return spells[index].cooldown <= 0;
    }

    /**
     * <summary>Casts spell at this unit's castpoint. If the spell couldn't be cast returns false.</summary>
     */
    public bool CastSpell(int index, Vector3 pos)
    {
        // Sugestie: 0 poate fi click dreapta, 1, 2, 3, 4 etc pot fi pe tastele 1, 2, 3, 4
        if (spells[index].Cast(this, pos))
            return true;
        return false;
    }

    public override bool CastAttack(Vector3 pos)
    {
        if (attackSpell.Cast(this, pos))
            return true;
        return false;
    }
}

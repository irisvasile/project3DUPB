using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAttributeBoost : Buff
{
    public float attackDamageBonus, attackSpeedBonus, movementSpeedBonus;
    public Attribute atr;

    public BuffAttributeBoost(string buffName, float durationMax, int stacksMax, float attackDamageBonus, float attackSpeedBonus, float movementSpeedBonus, Attribute atr, string impactName)
    {
        this.buffName = buffName;
        this.durationMax = durationMax;
        this.stacksMax = stacksMax;
        this.attackDamageBonus = attackDamageBonus;
        this.attackSpeedBonus = attackSpeedBonus;
        this.movementSpeedBonus = movementSpeedBonus;
        this.atr = atr;
        LoadImpact(impactName);
    }
    public override void OnApply(Unit target)
    {
        base.OnApply(target);
        ShowImpact(target);
    }


    public override void TriggeredUpdate(Unit target)
    {
        if (target == null)
            return;
        float finalADBonus, finalASBonus, finalMSBonus;
        int bonus;
        Hero hero = target.buffSources[this] as Hero;
        if (hero)
        {
            switch (atr)
            {
                case Attribute.DEX: bonus = hero.dexterity; break;
                case Attribute.STR: bonus = hero.strength; break;
                default: bonus = hero.wisdom; break;
            }
        }
        else
            bonus = 0;
        finalADBonus = 1 + (attackDamageBonus / 100) * (1 + bonus / 100);
        finalASBonus = 1 + (attackSpeedBonus / 100) * (1 + bonus / 100);
        finalMSBonus = 1 + (movementSpeedBonus / 100) * (1 + bonus / 100);
        target.attackDamageMin = Mathf.RoundToInt(target.attackDamageMin * finalADBonus);
        target.attackDamageMax = Mathf.RoundToInt(target.attackDamageMax * finalADBonus);
        target.attackCooldownMax /= finalASBonus;
        target.movementSpeed *= finalMSBonus;
    }

}

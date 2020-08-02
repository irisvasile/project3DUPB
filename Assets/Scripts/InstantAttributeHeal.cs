using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAttributeHeal : BuffInstant
{
    public float healing;
    public Attribute atr;

    public InstantAttributeHeal(float healing, Attribute atr, Buff nextBuff)
    {
        this.healing = healing;
        this.atr = atr;
        this.nextBuff = nextBuff;
    }

    public override void Execute(Unit target)
    {
        float bonus;
        Hero hero = target.buffSources[this] as Hero;
        if (!hero)
        {
            target.Heal(healing);
            return;
        }
        switch (atr)
        {
            case Attribute.DEX: bonus = hero.dexterity; break;
            case Attribute.STR: bonus = hero.strength; break;
            default: bonus = hero.wisdom; break;
        }
        if (hero.heroClass == HeroClass.CLERIC)
            healing *= 1.5f;
        target.Heal(healing * (1 + bonus / 100));
    }

    protected override void GenerateMainDescription()
    {
        description = "Restores " + healing + " health.";
        description += "\nEach point of " + atr + " increases effieciency by 1%.";
        description += "\nBeing a Cleric increases effieciency by 50%.";
    }
}

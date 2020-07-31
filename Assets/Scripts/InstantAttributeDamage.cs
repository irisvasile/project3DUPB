using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAttributeDamage : BuffInstant
{
    public float damage;
    public Attribute atr;

    public InstantAttributeDamage(float damage, Attribute atr, Buff effect)
    {
        this.damage = damage;
        this.atr = atr;
        this.effect = effect;
    }

    public override void Execute(Unit target)
    {
        int bonus;
        Hero hero = target.buffSources[this] as Hero;
        if (!hero)
        {
            target.TakeDamage(damage);
            return;
        }
        switch (atr)
        {
            case Attribute.DEX: bonus = hero.dexterity; break;
            case Attribute.STR: bonus = hero.strength; break;
            default: bonus = hero.wisdom; break;
        }
        if (hero.heroClass == HeroClass.WIZARD)
            damage *= 1.15f;
        target.TakeDamage(damage * (1 + bonus / 100));
    }
}

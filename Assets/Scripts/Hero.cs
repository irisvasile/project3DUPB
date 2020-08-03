using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    STR,
    DEX,
    WIS
}

public enum HeroClass
{
    WARRIOR,
    RANGER,
    WIZARD,
    CLERIC,
    ROGUE
}

public class Hero : ManaUser
{
    public int level = 1;
    public int strength = 10, dexterity = 10, wisdom = 10, points = 4;
    public float xp;
    public const int maxLevel = 10;
    public const int pointsPerLevel = 2;
    public const float healthPerLevel = 100;
    public const float manaPerLevel = 30;
    [HideInInspector]
    public PlayerInventory inventory;
    public const int goldPercentageLost = 10;
    public HeroClass heroClass;

    public void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        alliance = Alliance.Good;
        attackDamageMin = 9;
        attackDamageMax = 12;
        // doar pentru testing
        AddExperience(ExperienceForLevel(2));
        health /= 2;
        attackSpell = new SpellExplosion("Attack", 0, 0, 2.5f, new InstantAttackDamage(1), 0.5f, true, false, "ImpactHoly", false);
        SetSpell(0, "Arcane Missile");
        SetSpell(1, "Sanguine Shot");
        SetSpell(2, "Blink");
        SetSpell(3, "Rain of Arrows");
        SetSpell(4, "Fireball");
        SetSpell(5, "Hellfire");
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.LogWarning(spells[0].GetDescription());
    }

    /**
     * <summary>Adds experience to hero and checks if the hero should level up.</summary>
     */
    public void AddExperience(float amount)
    {
        xp += amount;
        while (xp >= ExperienceForLevel(level) && level != maxLevel)
        {
            LevelUp();
        }
    }

    /**
     * <summary>Formula for needed experience to go to the next level.
     * For experience needed for leveling to level 2, the parameter should be 1.</summary>
     */
    public float ExperienceForLevel(int lvl)
    {
        if (lvl == maxLevel)
            return ExperienceForLevel(lvl - 1);
        return lvl * lvl * 100;
    }

    /**
     * <summary>Levels the hero. Adds points to stats, increases hp and mp. Sets hp and mp to full. Announces level up.</summary>
     */
    public void LevelUp()
    {
        if (level == maxLevel)
            return;
        ++level;
        ++attackDamageMin;
        ++attackDamageMax;
        points += pointsPerLevel;
        healthMax += healthPerLevel;
        manaMax += manaPerLevel;
        health = healthMax;
        mana = manaMax;
        Debug.Log("Character has reached level " + level);
    }

    public void AddStrength()
    {
        if (points > 0)
        {
            --points;
            ++strength;
        }
    }

    public void AddDexterity()
    {
        if (points > 0)
        {
            --points;
            ++dexterity;
        }
    }

    public void AddWisdom()
    {
        if (points > 0)
        {
            --points;
            ++wisdom;
        }
    }

    /// <summary>When a hero dies, they lose a percentage of their gold.</summary>
    public override void Die()
    {
        int gold = inventory.gold;
        gold -= gold * goldPercentageLost / 100;
        inventory.gold = gold;
        Cleanse();
        health = healthMax / 2;
    }
}

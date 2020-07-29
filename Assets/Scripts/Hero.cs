using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : ManaUser
{
    public int level = 1;
    public int strength, agility, intelligence, points;
    public float xp;
    public const int pointsPerLevel = 5;
    public const float healthPerLevel = 20;
    public const float manaPerLevel = 5;
    [HideInInspector]
    public PlayerInventory inventory;
    public const int goldPercentageLost = 10;

    public void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        alliance = Alliance.Good;
        // doar pentru testing
        AddExperience(1400);
        health /= 2;
        attackSpell = new SpellExplosion("Attack", 0, 0, 2.5f, new InstantAttackDamage(1), 0.5f, true, false, "ImpactHoly");
        spells.Add(new SpellMissile("Arcane Missile", 1, 2, 40, new InstantDamage(1), 2, 2, true, "MissileArcane", "ImpactArcane"));
        spells.Add(new SpellMissile("Fireball", 5, 10, 40, new DebuffDOT("Fire", 8, 5, 2, 2), 2, 2, true, "MissileFire", "ImpactFire"));
        spells.Add(new SpellExplosion("Heal", 0, 20, 80, new InstantDamage(-10), 2, false, true, "ImpactHoly"));
        spells.Add(new SpellBlink("Blink", 2, 5, 40, new InstantDamage(1), 2, true, false, "ImpactArcane"));
        spells.Add(new SpellAoe("Hellfire", 10, 8, new DebuffDOT("Fire", 8, 5, 2, 2), 2, true, true, "ImpactFire"));

    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    /**
     * <summary>Adds experience to hero and checks if the hero should level up.</summary>
     */
    public void AddExperience(float amount)
    {
        xp += amount;
        while (xp >= ExperienceForLevel(level))
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
        return lvl * lvl * 100;
    }

    /**
     * <summary>Levels the hero. Adds points to stats, increases hp and mp. Sets hp and mp to full. Announces level up.</summary>
     */
    public void LevelUp()
    {
        ++level;
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

    public void AddAgility()
    {
        if (points > 0)
        {
            --points;
            ++agility;
        }
    }

    public void AddIntelligence()
    {
        if (points > 0)
        {
            --points;
            ++intelligence;
        }
    }

    /// <summary>When a hero dies, they lose a percentage of their gold.</summary>
    public new void Die()
    {
        int gold = inventory.gold;
        gold -= gold * goldPercentageLost / 100;
        inventory.gold = gold;
    }
}

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
        // doar pentru testing
        AddExperience(1400);
        attackSpell = new SpellExplosion("Attack", 0, 0, 2.5f, new InstantAttackDamage(1), 1.5f, true, false);
        spells.Add(new SpellBlink("Blink", 5, 5, 40, new InstantDamage(2), 60, true, true));
        alliance = Alliance.Good;
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

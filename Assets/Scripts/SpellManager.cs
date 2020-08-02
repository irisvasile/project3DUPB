using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager
{
    public static Dictionary<string, Spell> spells = new Dictionary<string, Spell>();
    public static Buff fire = new DebuffDOT("Fire", 10, 5, 2, 1, "ImpactFireTall");

    static SpellManager()
    {
        // spammable spells
        AddSpell(new SpellAoe("Cleave", 0.5f, 10, new InstantAttributeDamage(5, Attribute.STR, null), 5, true, false, "ImpactCrimson"));
        AddSpell(new SpellMissile("Arcane Missile", 0.5f, 20, 20, new InstantAttributeDamage(10, Attribute.WIS, null), 2, 2, true, "MissileArcane", "ImpactArcane"));
        AddSpell(new SpellMissile("Frost Shot", 0.5f, 15, 22, new InstantAttributeDamage(5, Attribute.DEX, new BuffAttributeBoost("Frost Shot", 4, 2, 0, -20, -20, Attribute.DEX, "")), 1, 3, true, "MissileFrost", "ImpactFrost"));

        AddSpell(new SpellMissile("Fireball", 4, 40, 20, new InstantAttributeDamage(2, Attribute.WIS, fire), 2, 10, true, "MissileFire", "ImpactFire"));
        AddSpell(new SpellMissile("Sanguine Shot", 10, 8, 30, new InstantAttributeDamage(25, Attribute.DEX, new DebuffDOT("Sanguine Shot", 2, 1, 1, 4, "ImpactCrimsonTall")), 2, 3, true, "MissileCrimson", "ImpactCrimson"));
        AddSpell(new SpellExplosion("Heal", 1, 20, 20, new InstantAttributeHeal(10, Attribute.WIS, null), 2, false, true, "ImpactHoly", false));
        AddSpell(new SpellExplosion("Rain of Arrows", 20, 45, 30, new InstantAttributeDamage(30, Attribute.DEX, null), 2, true, false, "ImpactRainOfArrows", false));
        AddSpell(new SpellExplosion("Blink", 2, 5, 20, new InstantAttributeDamage(2, Attribute.DEX, null), 2, true, false, "ImpactArcane", true));
        AddSpell(new SpellAoe("Hellfire", 6, 10, new InstantAttributeDamage(10, Attribute.STR, fire), 2.5f, true, true, "ImpactFire"));
        AddSpell(new SpellAoe("Smash", 10, 20, new InstantAttributeDamage(10, Attribute.STR, new DebuffStun("Smash", 2)), 2, true, true, "ImpactFire"));
        AddSpell(new SpellAoe("Blood Rush", 15, 10, new BuffAttributeBoost("Blood Rush", 4, 1, 0, 25, 5, Attribute.STR, "ImpactHoly"), 0, false, true, null));
    }

    static void AddSpell(Spell s)
    {
        spells.Add(s.spellName, s);
    }
}

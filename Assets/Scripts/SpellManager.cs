using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager
{
    public static Dictionary<string, Spell> spells = new Dictionary<string, Spell>();

    static SpellManager()
    {
        AddSpell(new SpellMissile("Arcane Missile", 1, 2, 40, new InstantAttributeDamage(1, Attribute.WIS), 2, 2, true, "MissileArcane", "ImpactArcane"));
        AddSpell(new SpellMissile("Fireball", 5, 10, 40, new DebuffDOT("Fire", 8, 5, 2, 2, 1), 2, 2, true, "MissileFire", "ImpactFire"));
        AddSpell(new SpellExplosion("Heal", 0, 20, 80, new InstantAttributeHeal(10, Attribute.WIS), 2, false, true, "ImpactHoly", false));
        AddSpell(new SpellExplosion("Blink", 2, 5, 40, new InstantAttributeDamage(2, Attribute.DEX), 2, true, false, "ImpactArcane", true));
        AddSpell(new SpellAoe("Hellfire", 10, 8, new DebuffDOT("Fire", 8, 5, 2, 2, 1), 2, true, true, "ImpactFire"));
    }

    static void AddSpell(Spell s)
    {
        spells.Add(s.spellName, s);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : ManaUser
{
    public float xpDropped = 0;
    /// <summary>Used for mob item and gold drops.</summary>
    public Inventory inventory;
    public List<string> spellNames = new List<string>();
    public Unit target;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        alliance = Alliance.Evil;
        int i = 0;
        foreach (string spellName in spellNames)
        {
            SetSpell(i++, spellName);
        }
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
        if (target != null)
            for (int i = 0; i < spellNames.Count; ++i)
                CastSpell(i, target.transform.position);
    }

    public override void Die()
    {
        foreach (Hero h in FindObjectsOfType<Hero>())
        {
            h.AddExperience(xpDropped);
        }
        base.Die();
    }
}

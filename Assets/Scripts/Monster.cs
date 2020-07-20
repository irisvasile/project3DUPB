using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : ManaUser
{
    public float xpDropped = 0;
    /// <summary>Used for mob item and gold drops.</summary>
    public Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        alliance = Alliance.Evil;
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Alliance
{
    Good, // Playeri, Pets, Minions, Mercenari, NPC care te ajuta in lupta, Gardieni in oras, Monstri posedati de playeri
    Evil, // Monstri, Creaturi, Bossi, Minioni posedati de inamici
    Neutral // Animale, Cufere, Cutii, Vaze. NPC din oras nu vor fi de tipul Unit pentru ca nu au nevoie de HP si nu au cum sa moara
}

public class Unit : MonoBehaviour
{
    public float health, healthMax;
    public List<Buff> buffs = new List<Buff>();
    [HideInInspector]
    public Alliance alliance;
    public int attackDamageMin, attackDamageMax;
    public float attackCooldownMax, attackCooldown = 0;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    public void FixedUpdate()
    {
        if (health <= 0 || transform.position.y <= -10)
            Die();
        for (int i = 0; i < buffs.Count; ++i)
        {
            Buff buff = buffs[i];
            buff.FixedUpdate();
            if (buffs.Count <= i)
                break;
            if (!buff.Equals(buffs[i]))
            {
                --i;
            }
        }
    }

    /**
     * <summary>Heals the unit, without overhealing.</summary>
     */
    public void Heal(float amount)
    {
        health += amount;
        if (health > healthMax)
        {
            health = healthMax;
        }
        else if (health <= 0)
            Die();
    }

    /**
     * <summary>Deals damage. If damage dealt brings health below 0, the unit dies.</summary>
     */
    public void TakeDamage(float amount)
    {
        Heal(-amount);
    }

    /**
     * <summary>Triggers the death of the unit.</summary>
     */
    public void Die()
    {
        Destroy(gameObject);
    }
    
    /**
     * <summary>Adds a buff to the unit.</summary>
     */
    public void ApplyBuff(Buff buff)
    {
        int i = 0;
        for (; i < buffs.Count && !buffs[i].Equals(buff); ++i) ;
        if (i != buffs.Count)
        {
            buffs[i].duration = Mathf.Max(buffs[i].duration, buff.duration);
            if (buffs[i].stacks < buffs[i].stacksMax)
                buffs[i].stacks++;
        }
        else
        {
            buffs.Add(buff);
            buff.target = this;
        }
    }

    /**
     * <summary>Removes a buff from the unit.</summary>
     */
    public void RemoveBuff(Buff buff)
    {
        buffs.Remove(buff);
    }

    /**
     * <summary>Checks if u is this unit's enemy.</summary>
     */
    public bool IsEnemy(Unit u)
    {
        if (alliance == Alliance.Good && u.alliance != Alliance.Good) // Pentru Good, Evil si Neutral sunt inamici
            return true;
        else if (alliance == Alliance.Evil && u.alliance == Alliance.Good) // Pentru Evil, doar Good e inamic
            return true;
        return false; // Pentru Neutral, nimeni nu e inamic
    }

    /**
     * <summary>Triggers the unit's attack.</summary>
     */
    public void Attack(Vector3 pos)
    {
        if (attackCooldown > 0)
        {
            /* if weapon equipped
                    weapon.Attack(Random.range(attackDamageMin, attackDamageMax));
               else
                    PunchAttack(Random.range(attackDamageMin, attackDamageMax));
             */
            attackCooldown = attackCooldownMax;
            return;
        }
    }
}

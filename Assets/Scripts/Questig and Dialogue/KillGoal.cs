using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class KillGoal : Goal
{
    public int EnemyId { get; set; }

    /**
     * <summary>A quest that requires slaying mobs.
     * Parametrul EnemyId va fi setat in functie de mobul care trebuie sa fie omorat.
     * </summary>
     */
    public KillGoal(Quest Quest,int EnemyId,string Description, bool completed, int CurrentAmount, int requiredAmount)
    {
        this.Quest = Quest;
        this.EnemyId = EnemyId;
        this.Description = Description;
        this.Completed = completed;
        this.CurrentAmmount = CurrentAmmount;
        this.RequiredAmount = requiredAmount;
    }
    public override void Init()
    {
        base.Init();
        CombatLog.EnemyDeath += EnemyDied;

    }
    void EnemyDied(Unit enemy)
    {
        if ( this.EnemyId == enemy.ID)
        {
            this.CurrentAmmount++;
            Debug.Log("nr curent de inamici "+this.CurrentAmmount);
            Evaluate();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLog : MonoBehaviour
{

    public delegate void EnemyEventHandler(Unit enemy);
    public static event EnemyEventHandler EnemyDeath;

    public static void EnemyDied(Unit enemy)
    {
        if (EnemyDeath != null)
            EnemyDeath(enemy);
            Debug.Log("Enemy died"+enemy.ID);
    }
}



using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggressiveMob : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private Transform[] playersPosition;
    public static bool ableToAttack;
    
    [SerializeField] private float detectionDistance = 10f;
    [SerializeField] private float attackDistance = 2.5f;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if (players == null)
        {
            Debug.LogError("No Players");
        }
    }

    private void Update()
    {
        float distance =
            Vector3.Distance(Helpers.GetClosestPlayer(this.transform, players).position, transform.position);
        if (distance < detectionDistance)
        {
            ableToAttack = true;
            if (distance > attackDistance)
            {
                
                MoveTowardsPlayer(Helpers.GetClosestPlayer(this.transform, players));
                navMeshAgent.isStopped = false;
                // print("MOVE TOWARDS THE CLOSEST PLAYER");
            }
            else
            {
                navMeshAgent.isStopped = true;
                print("ATTACK PLAYER");
            }
        }
        else
        {
            ableToAttack = false;
            // print("I DON'T SEE ANY PLAYER");
            // TODO: o sa aiba patrol
            // TODO: avand setate waypoints in functie de spawnpoint, se va intoarce singur catre spawnpoint sa patruleze.

        }
    }
    private void MoveTowardsPlayer(Transform closestPlayer)
    {
        Vector3 targetVector = closestPlayer.position;
        transform.LookAt(closestPlayer);
        navMeshAgent.SetDestination(targetVector);
        // TODO: if (distance < X) - AttackPlayer();
    }

}

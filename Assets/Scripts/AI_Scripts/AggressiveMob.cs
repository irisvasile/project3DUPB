using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggressiveMob : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private Transform[] playersPosition;

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
        if (Vector3.Distance(GetClosestPlayer(players).position, transform.position) < 10f)
        {
            print("ATTACK PLAYER");
            navMeshAgent.isStopped = false;
            MoveTowardsPlayer(GetClosestPlayer(players));
        }
        else
        {
            print("I DON'T SEE ANY PLAYER");
            navMeshAgent.isStopped = true;
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

    private Transform GetClosestPlayer(GameObject[] players)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(player.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = player.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}

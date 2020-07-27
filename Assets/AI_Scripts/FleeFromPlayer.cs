using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromPlayer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public GameObject[] players;
    public float distanceToRun = 5f;
    private Transform closestPlayer;

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
        // va fi folosit pentru LOW HP enemies.
        //if (this gameObject is low HP)
        Flee();
    }

    private void Flee()
    {
        closestPlayer = Helpers.GetClosestPlayer(this.transform, players);
        float distance = Vector3.Distance(transform.position, closestPlayer.position);
        //Debug.Log("Distance: " + distance);

        if (distance < distanceToRun)
        {
            Vector3 dirToPlayer = transform.position - closestPlayer.position;
            Vector3 newPos = transform.position + dirToPlayer;
            navMeshAgent.SetDestination(newPos);
        }
    }
}

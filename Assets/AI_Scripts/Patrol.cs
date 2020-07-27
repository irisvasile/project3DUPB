using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private Vector3[] wayPoints;
    private float waitTime;
    private int randomWayPoint;
    private NavMeshAgent navMeshAgent;
    private bool isMoving;
    private Rigidbody rb;

    [SerializeField] private int nrOfWayPoints = 10;
    [SerializeField] private float startWaitTime = 3;
    [SerializeField] private int maxPatrolDist = 3;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        wayPoints = new Vector3[nrOfWayPoints];
        waitTime = startWaitTime;
        rb = GetComponent<Rigidbody>();

        for (var i = 0; i < nrOfWayPoints; ++i)
        {
            var pos = transform.position;
            wayPoints[i] = new Vector3(pos.x + Random.Range(-maxPatrolDist, maxPatrolDist), pos.y,
                pos.z + Random.Range(-maxPatrolDist, maxPatrolDist));
        }
        randomWayPoint = Random.Range(0, wayPoints.Length);
    }

    private void Update()
    {
        if (AggressiveMob.ableToAttack == false)
        {
            MobPatrol();
        }
    }

    public void MobPatrol()
    {
         navMeshAgent.SetDestination(wayPoints[randomWayPoint]);
                
        //ignore height in computing the distance
        Vector3 aV = transform.position;
        Vector3 bV = wayPoints[randomWayPoint];
        aV.y = 0f;
        bV.y = 0f;
                
        if ((Vector3.Distance(aV, bV) < 0.2f) || (rb.velocity.magnitude < 0.2f))
        {
            if (waitTime <= 0)
            {
                randomWayPoint = Random.Range(0, wayPoints.Length);
                print("me changes waypoint");
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
                //print("me waits");
            }
        }
    }
}

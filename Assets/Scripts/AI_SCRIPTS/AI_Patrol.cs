using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{

    private Vector3[] wayPoints;
    private float waitTime;
    private int randomWayPoint;
    
    public int nrOfWayPoints = 10;
    public float movementSpeed = 5;
    public float startWaitTime = 3;
    
    private void Start()
    {
        wayPoints = new Vector3[nrOfWayPoints];
        waitTime = startWaitTime;
        
        for (var i = 0; i < nrOfWayPoints; ++i)
        {
            var pos = transform.position;
            wayPoints[i] = new Vector3(pos.x + Random.Range(-5, 5), pos.y,
             pos.z + Random.Range(-5, 5));
        }
        randomWayPoint = Random.Range(0, wayPoints.Length);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            wayPoints[randomWayPoint],
            movementSpeed * Time.deltaTime);

        if (!(Vector3.Distance(transform.position, wayPoints[randomWayPoint]) < 0.02f)) return;
        if (waitTime <= 0)
        {
            randomWayPoint = Random.Range(0, wayPoints.Length);
            waitTime = startWaitTime;
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}



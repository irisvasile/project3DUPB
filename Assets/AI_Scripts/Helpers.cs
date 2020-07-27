using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static Transform GetClosestPlayer(Transform caller, GameObject[] players)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = caller.position;
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

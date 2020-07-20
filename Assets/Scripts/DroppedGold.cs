using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedGold : MonoBehaviour
{
    public int gold;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory player = other.GetComponent<PlayerInventory>();
        if (player != null)
        {
           player.gold += gold;
           Destroy(gameObject);
        }
    }
}
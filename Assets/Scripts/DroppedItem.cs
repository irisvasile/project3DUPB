using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public Item item;

    private void PickUp(PlayerInventory player)
    {
        if (player.AddItem(item))
            Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsumable : Item
{
    ItemConsumable(int stackSizeMax)
    {
        this.stackSizeMax = stackSizeMax;
    }

    public override void Use()
    {
        --stackSize;
        if (stackSize <= 0)
            owner.RemoveItem(backpackIndex);
    }
}
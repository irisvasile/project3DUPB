using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipable : Item
{
    // slot pentru fiecare tip de item
    public ItemSlot slot;

    ItemEquipable(int price, ItemSlot slot)
    {
        this.price = price;
        this.slot = slot;
        stackSizeMax = 1;
    }

    public override void Use()
    {
        if (owner is PlayerInventory)
            ((PlayerInventory)owner).EquipItem(backpackIndex);
    }
}

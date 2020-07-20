using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

public class ItemEquipable : Item
{
    // slot pentru fiecare tip de item
    public ItemSlot slot;
    public Rarity rarity;

    ItemEquipable(int price, ItemSlot slot, Rarity rarity)
    {
        this.price = price;
        this.slot = slot;
        this.rarity = rarity;
        stackSizeMax = 1;
    }

    public override void Use()
    {
        ((PlayerInventory)owner).EquipItem(backpackIndex);
    }
}

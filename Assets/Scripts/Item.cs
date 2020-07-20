using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string itemName;
    public int stackSize, stackSizeMax;
    public Inventory owner;
    public int backpackIndex = -1;
    public int price;
    /// <summary>How much more expensive the item is while in a shop.</summary>
    public const int priceCoeficient = 10;

    public bool IsInPlayerInventory()
    {
        return owner != null && owner is PlayerInventory;
    }

    public int GetPrice()
    {
        if (IsInPlayerInventory())
            return price;
        return priceCoeficient * price;
    }

    public void SwapInventory()
    {
        if (backpackIndex == -1)
            return;
        // if (Vendor interface) {
        if (IsInPlayerInventory())
        {
            // Inventory vendor = get vendor inventory
            // owner.Sell(backpackindex, vendor);
        }
        else
        {
            // PlayerInventory player = get player inventory
            // player.Buy(backpackindex, owner);
        }
        //}
        //else if (Chest interface) {
        if (IsInPlayerInventory())
        {
            // Inventory chest = get chest inventory
            // owner.GiveItem(backpackindex, chest, true);
        }
        else
        {
            // PlayerInventory player = get player inventory
            // player.GiveItem(backpackindex, owner, true);
        }
        //}
    }

    public void Interact()
    {
        if (owner is PlayerInventory)
            Use();
    }

    public abstract void Use();
}

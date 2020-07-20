using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> backpackItems = new List<Item>();
    public int backpackSizeMax = 30;
    protected int backpackSize;
    public int gold = 0;

    public void Start()
    {
        backpackSize = 0;
        for (int i = 0; i < backpackSizeMax; ++i)
            backpackItems.Add(null);
    }

    /**
     * <summary>Checks whether the inventory is full.</summary>
     */
    public bool IsFull()
    {
        return backpackSize >= backpackSizeMax;
    }

    /**
     * <summary>Adds item to inventory. If it fails, it returns false. Item will not be dropped.</summary>
     */
    public bool AddItem(Item item)
    {
        if (!IsFull())
        {
            for (int i = 0; i < backpackItems.Count; ++i)
            {
                if (backpackItems[i] == null)
                {
                    backpackItems[i] = item;
                    ++backpackSize;
                    item.backpackIndex = i;
                    item.owner = this;
                    return true;
                }
            }
        }
        return false;
    }

    /**
     * <summary>Removes item in backpack at given index.</summary>
     */
    public void RemoveItem(int index)
    {
        backpackItems[index] = null;
        --backpackSize;
    }

    /**
     * <summary>Gives an item to a different inventory. If it fails, it will return false.
     * Set checkFullInventory to true if giving an item to a full inventory is alright.
     * Giving an item to a full inventory will destroy the item.</summary>
     */
    public bool GiveItem(int index, Inventory inv, bool checkFullInventory)
    {
        Item item = backpackItems[index];
        if (item == null || (checkFullInventory && inv.IsFull()))
            return false;
        RemoveItem(index);
        inv.AddItem(item);
        return true;
    }
}

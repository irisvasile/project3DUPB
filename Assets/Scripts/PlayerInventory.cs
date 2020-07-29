using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemSlot
{
    Helmet,
    Necklace,
    Shoulderpad,
    Chestplate,
    Belt,
    Leggings,
    Boots,
    Ring,
    Gloves
}

public class PlayerInventory : Inventory
{

    public Dictionary<ItemSlot, ItemEquipable> equippedItems = new Dictionary<ItemSlot, ItemEquipable>();
    [HideInInspector]
    public Hero hero;

    public void Start()
    {
        base.Start();
        hero = GetComponent<Hero>();
    }

    /**
     * <summary>Adds item to inventory. If it fails, the item will be dropped on the ground.</summary>
     */
    public void PickUpItem(Item item)
    {
        if (!AddItem(item))
        {
            //Drop item
            Debug.Log("Overburdened!");
        }
    }

    /**
     * <summary>Removes item equipped in given slot.</summary>
     */
    public void RemoveItem(ItemSlot slot)
    {
        equippedItems[slot] = null;
    }

    /**
     * <summary>If your inventory isn't full, unequips item in slot.</summary>
     */
    public void EquipItem(int index)
    {
        ItemEquipable item = (ItemEquipable)backpackItems[index];
        backpackItems[index] = equippedItems[item.slot];
        ForceEquipItem(item);
        item.backpackIndex = -1;
        if (backpackItems[index] == null)
            --backpackSize;
    }

    /**
     * <summary>If your inventory isn't full, unequips item in slot and adds it to your inventory.</summary>
     */
    public void UnequipItem(ItemSlot slot)
    {
        ItemEquipable item = equippedItems[slot];
        if (AddItem(item))
            RemoveItem(slot);
    }

    /**
     * <summary>Forces an item into its respective slot. Only used for debugging or when loading items.</summary>
     */
    public void ForceEquipItem(ItemEquipable item)
    {
        equippedItems[item.slot] = item;
        item.backpackIndex = -1;
    }

    public void SellToShop(int index, Inventory shop)
    {
        int newGold = gold + backpackItems[index].GetPrice();
        if (GiveItem(index, shop, false))
            gold = newGold;
    }

    public void BuyFromShop(int index, Inventory shop)
    {
        int newGold = gold - backpackItems[index].GetPrice();
        if (newGold >= 0 && shop.GiveItem(index, this, true))
            gold = newGold;
    }
}

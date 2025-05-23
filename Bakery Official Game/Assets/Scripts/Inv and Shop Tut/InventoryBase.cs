using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{
    public event Action OnInventoryChange;

    public int maxInventorySize = 10;
    public List<InventoryItem> itemList;

    public bool CanAddItem() => itemList.Count < maxInventorySize;

    public void AddItem(InventoryItem itemToAdd)
    {
        InventoryItem itemInInventory = FindItem(itemToAdd.itemData);

        if (itemInInventory != null)
            itemInInventory.AddStack();
        else
            itemList.Add(itemToAdd);

        OnInventoryChange?.Invoke();
    }

    public InventoryItem FindItem(ItemDataSO itemData)
    {
        return itemList.Find(item => item.itemData == itemData && item.CanAddStack());
    }
}

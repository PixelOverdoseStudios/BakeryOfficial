using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryItemSlot[] itemSlots;
    private InventoryBase inventory;

    private void Awake()
    {
        itemSlots = GetComponentsInChildren<InventoryItemSlot>();
        
        inventory = FindFirstObjectByType<InventoryBase>();
        inventory.OnInventoryChange += UpdateInventorySlots;

        UpdateInventorySlots();
    }

    private void UpdateInventorySlots()
    {
        List<InventoryItem> itemList = inventory.itemList;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < itemList.Count)
            {
                itemSlots[i].UpdateSlot(itemList[i]);
            }
            else
            {
                itemSlots[i].UpdateSlot(null);
            }
        }
    }
}

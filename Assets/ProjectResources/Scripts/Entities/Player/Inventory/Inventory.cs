using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public event Action OnItemPlacedInInventory;
    [HideInInspector] public event Action OnItemRemovedFromInventory;

    private List<InventoryItemModel> inventoryItems = new List<InventoryItemModel>();

    public void AddItem(InventoryItemModel item)
    {
        inventoryItems.Add(item);

        OnItemPlacedInInventory?.Invoke();
    }

    public void RemoveItem(InventoryItemModel item)
    {
        inventoryItems.Remove(item);

        OnItemRemovedFromInventory?.Invoke();
    }

    public List<InventoryItemModel> GetItemsList()
    {
        return new List<InventoryItemModel>(inventoryItems);
    }

    public int GetInventoryItemsCount()
    {
        return inventoryItems.Count;
    }
}
using UnityEngine;

public class InventoryItem : MonoBehaviour, IPickupable
{
    [SerializeField] private InventoryItemModel inventoryItem;

    public void Pickup(Inventory inventory)
    {
        inventory.AddItem(inventoryItem);
    }

    public void OnPickedup()
    {
        Destroy(gameObject);
    }
}
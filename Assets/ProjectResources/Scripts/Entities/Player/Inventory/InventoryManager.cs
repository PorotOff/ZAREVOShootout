using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
    }

    public void PickupItem(InventoryItemModel item)
    {
        inventory.AddItem(item);
    }

    public void DropItem(InventoryItemModel item)
    {

    }
}
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IPickupable pickupable = other.GetComponent<IPickupable>();

        if (pickupable != null)
        {
            pickupable.Pickup(inventory);            
            pickupable.OnPickedup();
        }
    }
}
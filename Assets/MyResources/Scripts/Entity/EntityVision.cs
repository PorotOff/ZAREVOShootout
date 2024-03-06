using UnityEngine;
using System;

public class EntityVision : MonoBehaviour
{
    public static event Action<Transform> OnEntitySeen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Zombie>())
        {
            OnEntitySeen?.Invoke(other.GetComponent<Transform>());
            Debug.Log("EntitySeen");
        }
    }
}
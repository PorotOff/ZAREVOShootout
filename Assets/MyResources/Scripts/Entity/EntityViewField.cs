using UnityEngine;
using System;

public class EntityViewField : MonoBehaviour
{
    public static event Action<Transform> OnEntityInViewField;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Entity>())
        {
            OnEntityInViewField?.Invoke(other.GetComponent<Transform>());
        }
    }
}
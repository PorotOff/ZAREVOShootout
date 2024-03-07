using UnityEngine;
using System;

public class EntityVision : MonoBehaviour
{
    public static event Action<Transform> OnEntityInViewField;
    public static event Action OnEntityOutViewField;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Entity>())
        {
            OnEntityInViewField?.Invoke(other.GetComponent<Transform>());
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Entity>())
        {
            OnEntityOutViewField?.Invoke();
        }
    }
}
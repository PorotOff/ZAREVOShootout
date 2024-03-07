using UnityEngine;
using System;

public class ZombieVision : EntityVision
{
    public static event Action<Transform> OnPlayerInViewField;
    public static event Action OnPlayerOutViewField;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>())
        {
            OnPlayerInViewField?.Invoke(other.GetComponent<Transform>());
        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Player>())
        {
            OnPlayerOutViewField?.Invoke();
        }
    }
}
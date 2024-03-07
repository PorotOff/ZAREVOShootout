using UnityEngine;
using System;

public class PlayerVision : EntityVision
{
    public static event Action<Transform> OnZombieInViewField;
    public static event Action OnZombieOutViewField;

    private Vector2 shootingArea;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.GetComponent<Zombie>())
        {
            OnZombieInViewField?.Invoke(other.GetComponent<Transform>());
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if(other.GetComponent<Zombie>())
        {
            OnZombieOutViewField?.Invoke();
        }
    }

    private void SetShootionArea(Vector2 shootingArea)
    {
        this.shootingArea = shootingArea;
    }
}
using UnityEngine;
using System;

public class PlayerShootingDistance : EntityViewField
{
    public static event Action<Transform> OnZombieInSootionArea;

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
            OnZombieInSootionArea?.Invoke(other.GetComponent<Transform>());
        }
    }

    private void SetShootionArea(Vector2 shootingArea)
    {
        this.shootingArea = shootingArea;
    }
}
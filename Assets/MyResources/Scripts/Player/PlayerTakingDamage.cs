using System;
using UnityEngine;

public class PlayerTakingDamage : EntityTakingDamage
{
    public static event Action OnPlayerTakedDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = other.gameObject.GetComponent<Zombie>();

            entity.TakeDamage(zombie.Damage);

            SendMessageAboutEntityTakedDamage();
            OnPlayerTakedDamage?.Invoke();
        }
    }
}
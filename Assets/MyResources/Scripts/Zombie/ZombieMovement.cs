using UnityEngine;

public class ZombieMovement : EntityMovement
{
    private Zombie zombie;

    private void Awake()
    {
        zombie = GetComponent<Zombie>();
    }

    private void FixedUpdate()
    {
        zombie.Move();
    }
}
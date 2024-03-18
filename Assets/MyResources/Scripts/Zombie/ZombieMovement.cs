using UnityEngine;

public class ZombieMovement : MonoBehaviour
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
using UnityEngine;

public class Player : Entity
{
    [Header("Movement settings")]
    [SerializeField] private Joystick joystick;

    public override void Move()
    {
        Vector2 movementDirection = joystick.GetNormalizedInput();

        entity.velocity = movementDirection * movementSpeed * speedModification;
    }
}
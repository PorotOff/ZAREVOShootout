using UnityEngine;

public class Player : Entity
{
    private Joystick joystick;

    private void OnEnable()
    {
        Joystick.OnInitializedNewJoystick += SetJoystick;
    }
    private void OnDisable()
    {
        Joystick.OnInitializedNewJoystick -= SetJoystick;
    }

    private void SetJoystick(Joystick joystick)
    {
        this.joystick = joystick;
    }

    public override void Move()
    {
        Vector2 movementDirection = joystick.GetNormalizedInput();

        entity.velocity = movementDirection * movementSpeed * speedModification;
    }
}
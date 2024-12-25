using UnityEngine;

public class PlayerMovementModel : MonoBehaviour, IMovable
{
	private Joystick joystick;

	private Rigidbody2D playerRigidbody;

	private float speed;

    public PlayerMovementModel(Joystick joystick, Rigidbody2D playerRigidbody, float speed)
    {
        this.joystick = joystick;
        this.playerRigidbody = playerRigidbody;
        this.speed = speed;
    }

    public void Move()
	{
		Vector2 movementDirection = joystick.GetNormalizedMovementDirection();
		playerRigidbody.linearVelocity = movementDirection * speed;
	}
}
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity
{
	public static UnityEvent<Player> OnPlayerSpawned = new UnityEvent<Player>();

	private Joystick joystick;

	private void OnEnable()
	{
		Joystick.OnJoystickInitialized.AddListener(SetJoystickForPlayer);
	}
	private void OnDisable()
	{
		Joystick.OnJoystickInitialized.RemoveListener(SetJoystickForPlayer);
	}

	private void Start()
	{
		OnPlayerSpawned?.Invoke(this);
	}

	public new void Move(float movementForce)
	{
		if (joystick != null)
		{
			Vector2 movementDirection = joystick.GetNormalizedInput();

			entityRigidbody.velocity = movementDirection * movementForce * movementForceModification;
		}
	}

	private void SetJoystickForPlayer(Joystick joystick)
	{
		this.joystick = joystick;
	}
}
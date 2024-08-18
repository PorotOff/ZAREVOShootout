using UnityEngine;

public class SlowDownGameAfterReleasingStick : MonoBehaviour
{
	const float normalGameSpeed = 1f;
	[SerializeField] private float slowedGameSpeed = 0.25f;

	private Joystick joystick;

	private void OnEnable()
	{
		Joystick.OnJoystickInitialized.AddListener(SetJoystick);
	}
	private void OnDisable()
	{
		Joystick.OnJoystickInitialized.RemoveListener(SetJoystick);

		if (joystick != null)
		{
			joystick.OnPlayerTouchedStick.RemoveListener(NormalizeGameSpeed);
			joystick.OnPlayerReleasedStick.RemoveListener(SlowDownGameSpeed);
		}
	}

	private void SetJoystick(Joystick joystick)
	{
		this.joystick = joystick;

		joystick.OnPlayerTouchedStick.AddListener(NormalizeGameSpeed);
		joystick.OnPlayerReleasedStick.AddListener(SlowDownGameSpeed);
	}

	private void SlowDownGameSpeed()
	{
		Time.timeScale = slowedGameSpeed;
	}
	private void NormalizeGameSpeed()
	{
		Time.timeScale = normalGameSpeed;
	}
}
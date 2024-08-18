using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGameHandler : MonoBehaviour
{
	public static UnityEvent OnGameStarted = new UnityEvent();

	private Joystick joystick;

	[SerializeField] private List<GameObject> objectsForHiddingAfterStartGame = new List<GameObject>();

	private void OnEnable()
	{
		Joystick.OnJoystickInitialized.AddListener(SetJoystick);
	}
	private void OnDisable()
	{
		Joystick.OnJoystickInitialized.RemoveListener(SetJoystick);

		joystick?.OnPlayerTouchedStick?.RemoveListener(HandleStartGame);
	}

	private void SetJoystick(Joystick joystick)
	{
		this.joystick = joystick;

		joystick?.OnPlayerTouchedStick?.AddListener(HandleStartGame);
	}

	private void HandleStartGame()
	{
		OnGameStarted?.Invoke();

		foreach (var objectForHidding in objectsForHiddingAfterStartGame)
		{
			objectForHidding.SetActive(false);
		}

		enabled = false;
	}
}
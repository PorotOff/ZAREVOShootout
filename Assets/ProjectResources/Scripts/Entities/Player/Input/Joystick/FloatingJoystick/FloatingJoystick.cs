using UnityEngine;

public class FloatingJoystick : Joystick
{
	private void OnEnable()
	{
		NotifyPlayerTouches.OnPlayerTouchedStick.AddListener(PlaceStickOnTouchPosition);
	}
	private void OnDisable()
	{
		NotifyPlayerTouches.OnPlayerTouchedStick.RemoveListener(PlaceStickOnTouchPosition);
	}

	private void PlaceStickOnTouchPosition()
	{
		Vector2 newJoystickPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		joystickRing.transform.position = newJoystickPostition;
		stick.anchoredPosition = originalPosition;
	}
}
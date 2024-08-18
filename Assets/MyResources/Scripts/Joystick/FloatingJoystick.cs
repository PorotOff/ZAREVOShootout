using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick, IPointerDownHandler, IPointerUpHandler
{
	protected override void Start()
	{
		base.Start();

		ShowJoystick(false);
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);

		ShowJoystick(true);

		Vector2 newJoystickPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		joystickRing.transform.position = newJoystickPostition;
		stick.anchoredPosition = originalPosition;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);

		ShowJoystick(false);
	}

	private void ShowJoystick(bool hiddingState)
	{
		joystickRing.gameObject.SetActive(hiddingState);
	}
}
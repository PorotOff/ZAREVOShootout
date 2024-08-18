using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	public static UnityEvent<Joystick> OnJoystickInitialized = new UnityEvent<Joystick>();
	public UnityEvent OnPlayerTouchedStick = new UnityEvent();
	public UnityEvent OnPlayerReleasedStick = new UnityEvent();

	[SerializeField] protected RectTransform joystickRing;
	[SerializeField] protected RectTransform stick;

	protected Vector2 originalPosition;

	[SerializeField][Range(0, 1)] private float boundaryRadius = 0.5f;

	protected virtual void Start()
	{
		originalPosition = stick.anchoredPosition;

		OnJoystickInitialized?.Invoke(this);
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		OnPlayerTouchedStick?.Invoke();
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
		Vector2 newPosition = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickRing, eventData.position, eventData.pressEventCamera, out newPosition);

		Vector2 direction = newPosition - originalPosition;
		float distance = Vector2.Distance(originalPosition, newPosition);

		if (distance > boundaryRadius * joystickRing.rect.width)
		{
			newPosition = originalPosition + direction.normalized * boundaryRadius * joystickRing.rect.width;
		}

		stick.anchoredPosition = newPosition;
	}
	public virtual void OnPointerUp(PointerEventData eventData)
	{
		OnPlayerReleasedStick?.Invoke();
	}

	public Vector2 GetNormalizedInput()
	{
		Vector2 input = stick.anchoredPosition / (boundaryRadius * joystickRing.rect.width);

		return new Vector2(Mathf.Clamp(input.x, -1, 1), Mathf.Clamp(input.y, -1, 1));
	}
}
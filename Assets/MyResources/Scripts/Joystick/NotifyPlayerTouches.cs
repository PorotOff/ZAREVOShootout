using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NotifyPlayerTouches : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static UnityEvent<Joystick> OnJoystickInitialized = new UnityEvent<Joystick>();
    public static UnityEvent OnPlayerTouchedStick = new UnityEvent();
    public static UnityEvent OnPlayerReleasedStick = new UnityEvent();

    private Joystick currentJoystick;

    private void Awake()
    {
        currentJoystick = GetComponent<Joystick>();
    }

    private void Start()
    {
        OnJoystickInitialized?.Invoke(currentJoystick);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPlayerTouchedStick?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPlayerReleasedStick?.Invoke();
    }
}
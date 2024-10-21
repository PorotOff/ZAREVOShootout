using UnityEngine;

public class HiddingFloatingJoystick : MonoBehaviour
{
    [SerializeField] protected RectTransform joystickRing;

    private void OnEnable()
	{
		NotifyPlayerTouches.OnPlayerTouchedStick.AddListener(ShowJoystick);
        NotifyPlayerTouches.OnPlayerReleasedStick.AddListener(HideJoystick);
	}
	private void OnDisable()
	{
		NotifyPlayerTouches.OnPlayerTouchedStick.RemoveListener(ShowJoystick);
        NotifyPlayerTouches.OnPlayerReleasedStick.RemoveListener(HideJoystick);
	}

    private void Start()
    {
        HideJoystick();
    }

    private void ShowJoystick()
    {
        joystickRing.gameObject.SetActive(true);
    }
    private void HideJoystick()
    {
        joystickRing.gameObject.SetActive(false);
    }
}
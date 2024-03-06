using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool hidding = false;

    protected override void Start()
    {
        base.Start();
        
        HideJoystick();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        
        ShowJoystick();

        Vector2 newJoystickPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        joystickRing.transform.position = newJoystickPostition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HideJoystick();
    }

    private void HideJoystick()
    {
        if(hidding)
        {
            joystickRing.gameObject.SetActive(false);
        }
    }

    private void ShowJoystick()
    {
        if(hidding)
        {
            joystickRing.gameObject.SetActive(true);
        }
    }
}

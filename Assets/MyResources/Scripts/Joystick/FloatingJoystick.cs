using UnityEngine;

public class FloatingJoystick : Joystick
{
    [SerializeField] private bool hidding = false;

    protected override void Start()
    {
        base.Start();
        
        HideJoystick();
    }

    private void OnMouseDown() {
        ShowJoystick();

        Vector2 newJoystickPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        joystickRing.transform.position = newJoystickPostition;
    }

    private void OnMouseUp() 
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

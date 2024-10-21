using UnityEngine;
using UnityEngine.Events;

public class NotifyStartGame : MonoBehaviour
{
    public static UnityEvent OnGameStarted = new UnityEvent();

    private void OnEnable()
    {
        NotifyPlayerTouches.OnPlayerTouchedStick?.AddListener(Notify);
    }
    private void OnDisable()
    {
        NotifyPlayerTouches.OnPlayerTouchedStick?.RemoveListener(Notify);
    }

    private void Notify()
    {
        OnGameStarted?.Invoke();
    }
}
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerDownHandler
{
    public static event Action OnGameStarted;
    private bool isGameStarted = false;

    private void OnEnable()
    {
        GameOver.OnGameOver += EndGame;
    }
    private void OnDisable()
    {
        GameOver.OnGameOver -= EndGame;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isGameStarted)
        {
            OnGameStarted?.Invoke();
            isGameStarted = true;

            Debug.Log("Game started");
        }

        Debug.Log("Player pressed the button");
    }

    public void EndGame()
    {
        isGameStarted = false;
    }
}

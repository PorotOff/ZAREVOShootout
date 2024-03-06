using System;
using UnityEngine;

public class StartGame : MonoBehaviour
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

    private void OnMouseDown()
    {
        if(!isGameStarted)
        {
            OnGameStarted?.Invoke();
            isGameStarted = true;

            Debug.Log("Game started");
        }
    }

    public void EndGame()
    {
        isGameStarted = false;
    }
}

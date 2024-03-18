using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event Action OnGameOver;

    private void OnEnable()
    {
        Player.OnPlayerHealthZero += EndGame;
    }
    private void OnDisable()
    {
        Player.OnPlayerHealthZero -= EndGame;
    }

    private void EndGame()
    {
        OnGameOver?.Invoke();
    }
}
using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event Action OnGameOver;

    private void OnEnable()
    {
        Entity.OnPlayerHealtZero += EndGame;
    }
    private void OnDisable()
    {
        Entity.OnPlayerHealtZero -= EndGame;
    }

    private void EndGame()
    {
        OnGameOver?.Invoke();
    }
}
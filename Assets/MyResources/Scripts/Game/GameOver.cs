using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event Action OnGameOver;

    private void OnEnable()
    {
        Entity.OnEntityHealtZero += EndGame;
    }
    private void OnDisable()
    {
        Entity.OnEntityHealtZero -= EndGame;
    }

    private void EndGame()
    {
        OnGameOver?.Invoke();
    }
}
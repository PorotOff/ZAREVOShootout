using UnityEngine;

public class HideMenuAfterStartGame : MonoBehaviour
{
    private void OnEnable()
    {
        StartGame.OnGameStarted += HideMenu;
    }
    private void OnDisable()
    {
        StartGame.OnGameStarted -= HideMenu;
    }

    private void HideMenu()
    {
        gameObject.SetActive(false);
        Debug.Log("Menu hided");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
	private void OnEnable()
	{
		GameOverHandler.OnGameOver.AddListener(Restart);
	}
	private void OnDisable()
	{
		GameOverHandler.OnGameOver.RemoveListener(Restart);
	}

	private void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
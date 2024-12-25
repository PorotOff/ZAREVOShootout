using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
	private void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
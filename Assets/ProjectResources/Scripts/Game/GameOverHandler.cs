using UnityEngine;
using UnityEngine.Events;

public class GameOverHandler : MonoBehaviour
{
	public static UnityEvent OnGameOver = new UnityEvent();

	private void OnEnable()
	{
		Entity.OnEntityHealthZero.AddListener(PlayerHealthZeroHandler);
	}
	private void OnDisable()
	{
		Entity.OnEntityHealthZero.RemoveListener(PlayerHealthZeroHandler);
	}

	private void PlayerHealthZeroHandler(Entity entity)
	{
		if (entity is Player)
		{
			OnGameOver?.Invoke();
		}
	}
}
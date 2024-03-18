using UnityEngine;

public class ClearBullet : MonoBehaviour
{
	private float lifeTime = 1.0f; // время жизни пули
	private float timer = 0.0f; // таймер для отслеживания времени жизни пули

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > lifeTime)
		{
			// Очистка пули
			gameObject.SetActive(false);
			timer = 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		gameObject.SetActive(false);
	}
}

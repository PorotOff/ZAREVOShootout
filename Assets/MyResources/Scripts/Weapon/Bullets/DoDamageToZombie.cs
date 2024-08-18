using UnityEngine;

public class DoDamageToZombie : MonoBehaviour
{
	private Bullet bullet;
	private Zombie zombie;

	private void Awake()
	{
		bullet = GetComponent<Bullet>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Zombie"))
		{
			zombie = other.gameObject.GetComponent<Zombie>();

			if (zombie != null)
			{
				zombie.TakeDamage(bullet.BulletDamage);
			}
		}
	}
}
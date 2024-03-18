using UnityEngine;

public class DoDamageToPlayer : MonoBehaviour
{
	private Zombie zombie;
	private Player player;

	private void Awake()
	{
		zombie = GetComponent<Zombie>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		player = other.gameObject.GetComponent<Player>();
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (player != null)
		{
			player.TakeDamage(zombie.Damage);
		}
	}
}

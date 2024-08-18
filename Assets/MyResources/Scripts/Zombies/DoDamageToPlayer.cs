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
		if (other.gameObject.CompareTag("Player"))
		{
			player = other.gameObject.GetComponent<Player>();
		}
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (player != null && other.gameObject.CompareTag("Player"))
		{
			player.TakeDamage(zombie.Damage);
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			player = null;
		}
	}
}
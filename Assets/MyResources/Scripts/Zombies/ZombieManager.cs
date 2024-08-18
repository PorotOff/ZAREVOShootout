using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieManager : MonoBehaviour
{
	public static UnityEvent<ZombieManager> OnZombiesListInitialised = new UnityEvent<ZombieManager>();

	private List<Zombie> zombies;

	private Entity player;

	private void Awake()
	{
		player = GetComponent<Player>();

		zombies = new List<Zombie>();
	}

	private void OnEnable()
	{
		Zombie.OnZombieSpawned.AddListener(AddZombieToZombiesList);

		GameOverHandler.OnGameOver.AddListener(ClearZombiesList);
	}
	private void OnDisable()
	{
		Zombie.OnZombieSpawned.RemoveListener(AddZombieToZombiesList);

		GameOverHandler.OnGameOver.RemoveListener(ClearZombiesList);
	}

	private void Start()
	{
		OnZombiesListInitialised?.Invoke(this);
	}

	public void AddZombieToZombiesList(Zombie zombie)
	{
		zombies.Add(zombie);
	}
	public void ClearZombiesList()
	{
		zombies.Clear();
	}

	public Transform FindClosestZombie()
	{
		Transform closestEnemy = null;

		float shortestDistanceToZombie = float.MaxValue;

		foreach (var zombie in zombies)
		{
			float newDistanceToZombie = Vector2.Distance(player.transform.position, zombie.transform.position);

			if (newDistanceToZombie < shortestDistanceToZombie)
			{
				shortestDistanceToZombie = newDistanceToZombie;

				closestEnemy = zombie.transform;
			}
		}

		return closestEnemy;
	}
}
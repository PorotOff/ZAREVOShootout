using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesListForAttack : MonoBehaviour
{
	public static event Action<ZombiesListForAttack> OnZombiesListInitialised;

	private List<Zombie> zombies;

	private Entity player;

	private void Awake()
	{
		player = GetComponent<Player>();

		zombies = new List<Zombie>();
	}

	private void OnEnable()
	{
		Zombie.OnZombieSpawned += AddZombieToEnemiesList;
	}
	private void OnDisable()
	{
		Zombie.OnZombieSpawned -= AddZombieToEnemiesList;
	}

	private void Start()
	{
		OnZombiesListInitialised?.Invoke(this);
	}

	public void AddZombieToEnemiesList(Zombie zombie)
	{
		zombies.Add(zombie);
	}
	// public void RemoveZombiewFromList(Zombie zombie)
	// {
	// 	if (zombies.Contains(zombie))
	// 	{
	// 		zombies.Remove(zombie);
	// 	}
	// }

	public Transform FindClosestEnemy()
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
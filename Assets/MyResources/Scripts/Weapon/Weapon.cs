using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private ZombiesListForAttack zombiesList;

	public static event Action<Weapon> OnWeaponInstalled;

	private GameObject playerForWeaponLink; // Персонаж для привязки оружия
	public GameObject PlayerForWeaponLink
	{
		get
		{
			return playerForWeaponLink;
		}
		private set { }
	}

	private Transform target;
	public Transform Target
	{
		get
		{
			return target;
		}
		private set { }
	}

	private void OnEnable()
	{
		ZombiesListForAttack.OnZombiesListInitialised += SetZombiesList;

		Player.OnPlayerSpawned += SetPlayer;
	}
	private void OnDisable()
	{
		ZombiesListForAttack.OnZombiesListInitialised -= SetZombiesList;

		Player.OnPlayerSpawned -= SetPlayer;
	}

	private void Start()
	{
		OnWeaponInstalled?.Invoke(this);
	}

	private void Update()
	{
		SetTarget();
	}

	private void SetZombiesList(ZombiesListForAttack zombiesList)
	{
		this.zombiesList = zombiesList;
	}

	private void SetPlayer(Player player)
	{
		playerForWeaponLink = player.gameObject;
	}

	private void SetTarget()
	{
		target = zombiesList.FindClosestEnemy();
	}
}
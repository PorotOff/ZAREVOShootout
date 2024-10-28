using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private ZombieManager zombieManager;

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

	private Transform target = null;
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
		ZombieManager.OnZombiesListInitialised.AddListener(SetZombieManager);

		Player.OnPlayerSpawned.AddListener(SetPlayer);
	}
	private void OnDisable()
	{
		ZombieManager.OnZombiesListInitialised.RemoveListener(SetZombieManager);

		Player.OnPlayerSpawned.RemoveListener(SetPlayer);
	}

	private void Start()
	{
		OnWeaponInstalled?.Invoke(this);
	}

	private void Update()
	{
		SetTarget();
	}

	private void SetZombieManager(ZombieManager zombieManager)
	{
		this.zombieManager = zombieManager;
	}

	private void SetPlayer(Player player)
	{
		playerForWeaponLink = player.gameObject;
	}

	private void SetTarget()
	{
		target = zombieManager.FindClosestZombie();
	}
}
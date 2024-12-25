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

	private void Start()
	{
		OnWeaponInstalled?.Invoke(this);
	}

	private void SetZombieManager(ZombieManager zombieManager)
	{
		this.zombieManager = zombieManager;
	}
}
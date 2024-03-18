using System;
using UnityEngine;

public class Zombie : Entity, IMovable
{
	public static event Action<Zombie> OnZombieSpawned;
	public static event Action OnZombieHealthZero;

	[Header("Damage settings")]
	[SerializeField] private int damage = 5;
	public int Damage
	{
		get
		{
			return damage;
		}
		protected set
		{
			damage = value;

			if (value < 0)
			{
				damage = 0;
			}
		}
	}

	private Transform target;
	private Vector2 moveDirection = Vector2.zero;

	private void OnEnable()
	{
		Player.OnPlayerSpawned += SetTarget;
		Player.OnPlayerHealthZero += ClearTarget;
	}
	private void OnDisable()
	{
		Player.OnPlayerSpawned -= SetTarget;
		Player.OnPlayerHealthZero += ClearTarget;
	}

	protected void Start()
	{
		OnZombieSpawned?.Invoke(this);
	}

	private void SetTarget(Player target)
	{
		this.target = target.gameObject.transform;
	}
	private void ClearTarget()
	{
		target = null;
	}

	public void Move()
	{
		if (target != null)
		{
			moveDirection = (Vector2)target.position - (Vector2)transform.position;

			entity.velocity = moveDirection.normalized * movementSpeed;
		}
	}
}
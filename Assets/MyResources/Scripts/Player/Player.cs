using System;
using UnityEngine;

public class Player : Entity, IMovable
{
	public static event Action<Player> OnPlayerSpawned;

	public static event Action<Player> OnPlayerTakedDamage;
	public static event Action OnPlayerHealthZero;

	public override int Health
	{
		get
		{
			return health;
		}
		protected set
		{
			health = value;

			if (health < 0)
			{
				health = 0;

				OnPlayerHealthZero?.Invoke();

				gameObject.SetActive(false);
			}
		}
	}

	private Joystick joystick;

	private void OnEnable()
	{
		Joystick.OnInitializedNewJoystick += SetJoystick;
	}
	private void OnDisable()
	{
		Joystick.OnInitializedNewJoystick -= SetJoystick;
	}

	private void Start()
	{
		OnPlayerSpawned?.Invoke(this);
	}

	private void SetJoystick(Joystick joystick)
	{
		this.joystick = joystick;
	}

	public void Move()
	{
		Vector2 movementDirection = joystick.GetNormalizedInput();

		entity.velocity = movementDirection * movementSpeed * speedModification;
	}

	public override void TakeDamage(int damage)
	{
		Health -= damage;

		OnPlayerTakedDamage?.Invoke(this);
	}
}
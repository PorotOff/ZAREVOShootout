using UnityEngine;

public class Entity : MonoBehaviour
{
	protected Rigidbody2D entity;

	[Header("Movement settings")]
	[SerializeField] protected float movementSpeed = 5f;
	[SerializeField] protected float speedModification = 1f;

	[Header("Health settings")]
	protected int health;
	public virtual int Health
	{
		get
		{
			return health;
		}
		protected set { }
	}
	[SerializeField] private int maxHealth = 100;
	public int MaxHealth
	{
		get
		{
			return maxHealth;
		}
		private set { }
	}

	protected virtual void Awake()
	{
		entity = GetComponent<Rigidbody2D>();

		health = maxHealth;
	}

	public virtual void TakeDamage(int damage)
	{

	}
}
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour, IMovable, IDamagable
{
	public UnityEvent<Entity> OnEntityHealtChanged = new UnityEvent<Entity>();
	public static UnityEvent<Entity> OnEntityHealthZero = new UnityEvent<Entity>();

	protected Rigidbody2D entityRigidbody;

	[Header("Movement settings")]
	[SerializeField] protected float movementForce = 5f;
	public float MovementForce
	{
		get
		{
			return movementForce;
		}
	}
	[SerializeField] protected float movementForceModification = 1f;
	public float MovementForceModification
	{
		get
		{
			return movementForceModification;
		}
	}

	[Header("Health settings")]
	protected int health;
	public virtual int Health
	{
		get
		{
			return health;
		}
		protected set
		{
			health = value;

			OnEntityHealtChanged.Invoke(this);

			if (health <= 0)
			{
				health = 0;

				OnEntityHealthZero?.Invoke(this);

				gameObject.SetActive(false);
			}
		}
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
		entityRigidbody = GetComponent<Rigidbody2D>();

		Health = maxHealth;
	}

	public void Move(float movementForce) { }
	public void ModificateSpeed(float speedModification)
	{
		movementForce += speedModification;
	}

	public virtual void TakeDamage(int damage)
	{
		Health -= damage;

		Debug.Log($"The {GetType().Name} taked damage");
	}
}
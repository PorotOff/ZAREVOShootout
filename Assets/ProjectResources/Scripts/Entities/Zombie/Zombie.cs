using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Zombie : Entity, IMovable
{
	public static UnityEvent<Zombie> OnZombieSpawned = new UnityEvent<Zombie>();

	private NavMeshAgent navMeshAgent;

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

	protected override void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.updateRotation = false;
		navMeshAgent.updateUpAxis = false;
	}
	private void Start()
	{
		OnZombieSpawned?.Invoke(this);
	}
}
using UnityEngine;

public class Zombie : Entity
{
    private Rigidbody2D zombie;

    [Header("Damage settings")]
    [SerializeField] protected int damage = 5;
    public int Damage 
    {
        get
        {
            return damage;
        }
        private set
        {
            damage = value;
        }
    }

    private Transform target;

    private void Awake()
    {
        zombie = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ZombieVision.OnPlayerInViewField += SetTarget;
        ZombieVision.OnPlayerOutViewField += ClearTarget;
    }
    private void OnDisable()
    {
        ZombieVision.OnPlayerInViewField -= SetTarget;
        ZombieVision.OnPlayerOutViewField -= ClearTarget;
    }

    private void SetTarget(Transform target)
    {
        this.target = target;
    }
    private void ClearTarget()
    {
        target = null;
    }

    public override void Move()
    {
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;

        zombie.velocity = direction.normalized * movementSpeed;
    }
}
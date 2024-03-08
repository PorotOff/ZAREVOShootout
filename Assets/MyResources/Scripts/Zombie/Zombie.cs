using UnityEngine;

public class Zombie : Entity
{

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
    private Vector2 direction = Vector2.zero;

    private void OnEnable()
    {
        OnEntitySpawned += SetTarget;
    }
    private void OnDisable()
    {
        OnEntitySpawned -= SetTarget;
    }

    private void SetTarget(Entity player)
    {
        target = player.gameObject.transform;
    }
    private void ClearTarget()
    {
        target = null;
    }

    public override void Move()
    {
        if(target != null)
        {
            direction = (Vector2)target.position - (Vector2)transform.position;

            entity.velocity = direction.normalized * movementSpeed;
        }
    }
}
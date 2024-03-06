using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D entity;

    [Header("Movement settings")]
    [SerializeField] protected float movementSpeed = 5f;
    [SerializeField] protected float speedModification = 1f;

    [Header("Health settings")]
    [SerializeField] protected int health;
    public int Health
    {
        get
        {
            return health;
        }
        private set
        {
            health = value;

            if(value < 0)
            {
                health = 0;
            }
        }
    }
    [SerializeField] protected int maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        private set
        {
            maxHealth = value;

            if(value < 0)
            {
                maxHealth = 0;
            }
        }
    }
    public static event Action OnPlayerHealtZero;

    private void Awake() {
        entity = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public virtual void Move() 
    {
        //разная реализация для производных классов
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            OnPlayerHealtZero?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable, IHealable
{
    public event Action OnTakedDamage;
    public event Action OnHealed;
    public event Action OnHealtZero;
    public event Action OnHealthChanged;

    private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;

            OnHealtZero?.Invoke();
            OnHealthChanged?.Invoke();

            return;
        }

        currentHealth -= damage;

        OnTakedDamage?.Invoke();
        OnHealthChanged?.Invoke();
    }
    public void Heal(int healthPoints)
    {
        currentHealth += Mathf.Abs(healthPoints);

        OnHealed?.Invoke();
        OnHealthChanged?.Invoke();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
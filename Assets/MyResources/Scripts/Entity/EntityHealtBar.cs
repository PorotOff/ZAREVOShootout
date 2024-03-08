using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    protected Entity entity;
    protected Slider healthBarSlider;

    protected virtual void Awake()
    {
        healthBarSlider = GetComponent<Slider>();
        UpdateHealthBarValue();
    }

    protected virtual void OnEnable()
    {
        EntityTakingDamage.OnEntityTakedDamage += UpdateHealthBarValue;

        Entity.OnEntitySpawned += SetEntity;
    }
    protected virtual void OnDisable()
    {
        EntityTakingDamage.OnEntityTakedDamage -= UpdateHealthBarValue;

        Entity.OnEntitySpawned -= SetEntity;
    }

    protected void UpdateHealthBarValue()
    {
        if (entity != null)
        {
            healthBarSlider.value = entity.Health;
        }
    }

    protected void SetEntity(Entity entity)
    {
        this.entity = entity;
        UpdateHealthbar(entity);
    }

    private void UpdateHealthbar(Entity entity)
    {
        healthBarSlider.maxValue = entity.MaxHealth;
        UpdateHealthBarValue();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    [SerializeField] private Entity entity;
    private Slider healthBarSlider;

    private void Awake()
    {
        healthBarSlider = GetComponent<Slider>();
        healthBarSlider.maxValue = entity.MaxHealth;
    }

    private void Start()
    {
        UpdateHealthBarValue();
    }

    private void OnEnable()
    {
        EntityTakingDamage.OnEntityTakedDamage += UpdateHealthBarValue;
    }
    private void OnDisable()
    {
        EntityTakingDamage.OnEntityTakedDamage -= UpdateHealthBarValue;
    }

    private void UpdateHealthBarValue()
    {
        healthBarSlider.value = entity.Health;
    }
}

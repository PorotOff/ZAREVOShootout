using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
	protected Entity entity;
	protected Slider healthBarSlider;

	protected virtual void Awake()
	{
		healthBarSlider = GetComponent<Slider>();

		entity = GetComponentInParent<Entity>();

		healthBarSlider.maxValue = entity.MaxHealth;
	}

	private void Start()
	{
		UpdateHealthbar(entity);
	}

	protected void UpdateHealthbar(Entity entity)
	{
		if (entity != null)
		{
			healthBarSlider.value = entity.Health;
		}
	}
}

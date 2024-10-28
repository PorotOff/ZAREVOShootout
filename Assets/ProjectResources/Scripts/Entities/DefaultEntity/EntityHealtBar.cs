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

		if (entity != null)
		{
			healthBarSlider.maxValue = entity.MaxHealth;
			entity.OnEntityHealtChanged.AddListener(UpdateHealthbar);
			UpdateHealthbar(entity);
		}
	}

	private void OnEnable()
	{
		entity?.OnEntityHealtChanged?.AddListener(UpdateHealthbar);

		UpdateHealthbar(entity);
	}
	private void OnDisable()
	{
		entity?.OnEntityHealtChanged?.RemoveListener(UpdateHealthbar);
	}

	protected void UpdateHealthbar(Entity entity)
	{
		if (entity != null)
		{
			healthBarSlider.value = entity.Health;
		}
	}
}
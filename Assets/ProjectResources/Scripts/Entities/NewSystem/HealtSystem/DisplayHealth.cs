using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
	private Health health;
	private Slider healthBarSlider;

	private void Awake()
	{
		healthBarSlider = GetComponent<Slider>();
		health = GetComponentInParent<Health>();

		healthBarSlider.maxValue = health.GetMaxHealth();

		UpdateHealthbar();
	}

	private void OnEnable()
	{
		health.OnHealthChanged += UpdateHealthbar;
	}
	private void OnDisable()
	{
		health.OnHealthChanged += UpdateHealthbar;
	}

	private void UpdateHealthbar()
	{
		healthBarSlider.value = health.GetCurrentHealth();
	}
}
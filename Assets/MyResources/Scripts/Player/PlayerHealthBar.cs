using UnityEngine;

public class PlayerHealthBar : EntityHealthBar
{
	private void OnEnable()
	{
		Player.OnPlayerTakedDamage += UpdateHealthbar;
	}
	private void OnDisable()
	{
		Player.OnPlayerTakedDamage -= UpdateHealthbar;
	}
}
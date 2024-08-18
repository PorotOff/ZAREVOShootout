using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
	[Range(0, 5)] public float orbitRadius = 1f; // Радиус орбиты оружия вокруг персонажа
	private bool facingRight = true; // Направление персонажа

	public Weapon weapon;
	public Vector2 weaponDirection = Vector2.zero;

	private IWeaponState currentWeaponState;

	private void Awake()
	{
		weapon = GetComponent<Weapon>();

		currentWeaponState = new NoWeaponRotationState();
	}

	private void OnEnable()
	{
		StartGameHandler.OnGameStarted.AddListener(SetWeaponRotationState);
	}
	private void OnDisable()
	{
		StartGameHandler.OnGameStarted.RemoveListener(SetWeaponRotationState);
	}

	private void Update()
	{
		currentWeaponState.Handle(this);
	}

	public void SetWeaponDirection()
	{
		if (weapon.Target != null && weapon.PlayerForWeaponLink != null)
		{
			weaponDirection = (weapon.Target.position - weapon.PlayerForWeaponLink.transform.position).normalized;

			// Проверяем, в какую сторону должен быть повернут персонаж
			if (weaponDirection.x > 0 && !facingRight)
			{
				Flip();
			}
			else if (weaponDirection.x < 0 && facingRight)
			{
				Flip();
			}
		}
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}

	private void SetWeaponRotationState()
	{
		currentWeaponState = new WeaponRotationAfterStartState();
	}
}

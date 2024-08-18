using UnityEngine;

public class WeaponRotationAfterStartState : IWeaponState
{
	public void Handle(WeaponRotation weaponRotation)
	{
		weaponRotation.SetWeaponDirection();

		// Вычисляем угол между направлением оружия и осью X
		float angle = Mathf.Atan2(weaponRotation.weaponDirection.y, weaponRotation.weaponDirection.x) * Mathf.Rad2Deg;
		Vector2 weaponPosition = (Vector2)weaponRotation.weapon.PlayerForWeaponLink.transform.position + weaponRotation.weaponDirection * weaponRotation.orbitRadius;

		weaponRotation.transform.rotation = Quaternion.Euler(0, 0, angle);
		weaponRotation.transform.position = new Vector3(weaponPosition.x, weaponPosition.y, weaponRotation.transform.position.z);
	}
}
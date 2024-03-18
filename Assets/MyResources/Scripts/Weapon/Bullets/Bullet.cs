using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody2D bullet;
	[SerializeField] private int bulletDamage = 5;
	public int BulletDamage
	{
		get
		{
			return bulletDamage;
		}
		private set
		{
			bulletDamage = value;
		}
	}

	[SerializeField] private float bulletFlySpeed = 10f;

	private BulletActivator bulletActivator;
	private Weapon weapon;
	public Weapon Weapon
	{
		get
		{
			return weapon;
		}
		private set { }
	}

	private void Awake()
	{
		bullet = GetComponent<Rigidbody2D>();
		bulletActivator = GetComponentInParent<BulletActivator>();

		weapon = bulletActivator.Weapon;
	}

	public void GetFlyImpulse()
	{
		if (weapon != null && weapon.Target != null)
		{
			Vector2 flyDirection = (Vector2)weapon.Target.position - (Vector2)bullet.transform.position;

			bullet.AddForce(flyDirection.normalized * bulletFlySpeed, ForceMode2D.Impulse);

			RotateBulletToEnemySide(flyDirection);
		}
	}

	private void RotateBulletToEnemySide(Vector2 flyDirection)
	{
		float angle = Mathf.Atan2(flyDirection.y, flyDirection.x) * Mathf.Rad2Deg;

		bullet.rotation = angle + bullet.transform.rotation.z;
	}

}
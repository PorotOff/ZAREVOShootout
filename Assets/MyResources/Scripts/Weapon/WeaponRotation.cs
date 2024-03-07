using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] private float orbitRadius = 1f; // Радиус орбиты оружия вокруг персонажа
    private bool facingRight = true; // Направление персонажа

    private Weapon weapon;
    Vector2 weaponDirection = Vector2.zero;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        FindWeaponDirection();

        // Вычисляем угол между направлением оружия и осью X
        float angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg;
        Vector2 weaponPosition = (Vector2)weapon.PlayerForWeaponLink.transform.position + weaponDirection * orbitRadius;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = new Vector3(weaponPosition.x, weaponPosition.y, transform.position.z);
    }

    private void FindWeaponDirection()
    {
        if (weapon.Target != null)
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
}

using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    private GameObject player; // Персонаж
    [SerializeField] [Range(0, 5)] private float orbitRadius = 1f; // Радиус орбиты оружия вокруг персонажа
    private bool facingRight = true; // Направление персонажа

    private Transform target; // Зомби, который вошёл в поле зрения игрока

    private void OnEnable()
    {
        Entity.OnEntitySpawned += SetPlayer;
        PlayerShootingDistance.OnZombieInSootingArea += SetTarget;
    }
    private void OnDisable()
    {
        Entity.OnEntitySpawned -= SetPlayer;
        PlayerShootingDistance.OnZombieInSootingArea += SetTarget;
    }

    private void Update()
    {
        Vector2 weaponDirection;
        
        if (target != null)
        {
            weaponDirection = (target.position - player.transform.position).normalized;
            // Проверяем, в какую сторону должен быть повернут персонаж
            if (weaponDirection.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (weaponDirection.x < 0 && facingRight)
            {
                Flip();
            }

            // Вычисляем угол между направлением оружия и осью X
            float angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg;
            // Устанавливаем поворот оружия вокруг оси Z
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            // Если зомби нет в поле зрения, оружие остается в том же направлении
            weaponDirection = transform.right;
        }

        // Оружие всегда двигается вместе с игроком
        Vector2 weaponPosition = (Vector2)player.transform.position + weaponDirection * orbitRadius;
        transform.position = new Vector3(weaponPosition.x, weaponPosition.y, transform.position.z);
    }

    // Функция для переворота персонажа
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    private void SetPlayer(Entity player)
    {
        this.player = player.gameObject;
    }
    private void SetTarget(Transform target)
    {
        this.target = target;
    }
}

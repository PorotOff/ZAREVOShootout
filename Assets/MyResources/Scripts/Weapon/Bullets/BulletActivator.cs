using UnityEngine;

public class BulletActivator : MonoBehaviour
{
    private Transform bulletContainer;

    private Weapon weapon;
    public Weapon Weapon
    {
        get
        {
            return weapon;
        }
        private set{}
    }

    private float timer = 0f; // таймер для метода Update
    [SerializeField] private float activationInterval = 0.3f; // время активации пули

    private void Awake()
    {
        bulletContainer = GetComponent<Transform>();
    }

    private void Update()
    {
        // Вызов метода через Update с таймером
        timer += Time.deltaTime;
        if (timer > activationInterval)
        {
            ActivateBullet();
            timer = 0;
        }
    }

    private void OnEnable()
    {
        Weapon.OnWeaponInstalled += SetWeapon;
    }
    private void OnDisable()
    {
        Weapon.OnWeaponInstalled -= SetWeapon;
    }

    private void ActivateBullet()
    {
        if(weapon.Target != null)
        {
            foreach (Transform bullet in bulletContainer)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    bullet.position = weapon.gameObject.transform.position;
                    bullet.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon; 
    }
}

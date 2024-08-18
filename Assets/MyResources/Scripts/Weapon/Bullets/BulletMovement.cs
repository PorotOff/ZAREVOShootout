using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Bullet bullet;

    private void Awake()
    {
        bullet = GetComponent<Bullet>();
    }

    private void OnEnable()
    {
        bullet.GetFlyImpulse();
    }
}
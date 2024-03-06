using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    private Transform target; // Цель, за которой будет следить оружие
    [SerializeField] [Range(0, 1)] private float boundaryRadius = 0.5f; // Граница, за которую не может выйти оружие

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnEnable()
    {
        EntityVision.OnEntitySeen += DetermineTargetForShooting;
    }
    private void OnDisable()
    {
        EntityVision.OnEntitySeen -= DetermineTargetForShooting;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - originalPosition;
            float distance = Vector2.Distance(originalPosition, target.position);

            if (distance > boundaryRadius)
            {
                direction = originalPosition + direction.normalized * boundaryRadius;
            }

            // Поворачиваем оружие в сторону цели
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }

    private void DetermineTargetForShooting(Transform tragetForShooting)
    {
        target = tragetForShooting;
    }
}

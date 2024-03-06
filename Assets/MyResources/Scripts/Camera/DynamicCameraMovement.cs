using UnityEngine;

public class DynamicCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothingMovement = 0.1f;

    private void Update()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingMovement);
    }
}

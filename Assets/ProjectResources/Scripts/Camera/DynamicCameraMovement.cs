using UnityEngine;

public class DynamicCameraMovement : MonoBehaviour, IMovable
{
    private Transform cameraTransform { get; set; }
    private Transform target { get; set; }

    private float smoothingRatio { get; set; }

    public void Initialise(Transform target, float smoothingRatio)
    {
        cameraTransform = transform;
        this.target = target;
        this.smoothingRatio = smoothingRatio;
    }
    
    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Move();
    }

    public void Move()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.z = cameraTransform.position.z;

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, smoothingRatio);
    }
}

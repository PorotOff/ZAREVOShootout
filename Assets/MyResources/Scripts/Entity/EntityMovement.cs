using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponent<Entity>();
    }

    private void FixedUpdate()
    {
        entity.Move();
    }
}
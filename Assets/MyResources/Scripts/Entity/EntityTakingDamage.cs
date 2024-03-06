using System;
using UnityEngine;

public class EntityTakingDamage : MonoBehaviour
{
    protected Entity entity;
    public static event Action OnEntityTakedDamage;

    protected void Awake()
    {
        entity = GetComponent<Entity>();
    }

    protected void SendMessageAboutEntityTakedDamage()
    {
        OnEntityTakedDamage?.Invoke();
    }
}
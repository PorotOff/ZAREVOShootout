using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject playerForWeaponLink; // Персонаж для привязки оружия
    public GameObject PlayerForWeaponLink
    {
        get
        {
            return playerForWeaponLink;
        }
        private set{}
    }

    private Transform target;
    public Transform Target
    {
        get
        {
            return target;
        }
        private set{}
    }

    public static event Action<Weapon> OnWeaponInstalled;

    private void Start()
    {
        OnWeaponInstalled?.Invoke(this);
    }

    private void OnEnable()
    {
        Entity.OnEntitySpawned += SetPlayer;

        PlayerVision.OnZombieInViewField += SetTarget;
        PlayerVision.OnEntityOutViewField += ClearTarget;
    }
    private void OnDisable()
    {
        Entity.OnEntitySpawned -= SetPlayer;

        PlayerVision.OnZombieInViewField -= SetTarget;
        PlayerVision.OnEntityOutViewField -= ClearTarget;
    }

    private void SetPlayer(Entity player)
    {
        playerForWeaponLink = player.gameObject;
    }

    private void SetTarget(Transform target)
    {
        this.target = target;
    }
    private void ClearTarget()
    {
        target = null;
    }
}
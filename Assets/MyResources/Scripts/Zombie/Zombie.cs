using UnityEngine;

public class Zombie : Entity
{
    [Header("Damage settings")]
    [SerializeField] protected int damage = 5;
    public int Damage 
    {
        get
        {
            return damage;
        }
        private set
        {
            damage = value;
        }
    }
}
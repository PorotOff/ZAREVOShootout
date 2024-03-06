using UnityEngine;

public class Zombie : Entity
{
    [SerializeField] private int damage = 5;
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
using System;
using UnityEngine;

[Serializable]
public class KilledZombie
{
    public int KilledZombieCount { get; set; }

    public void AddKilledZombieNumber(int killedZombieNumber)
    {
        KilledZombieCount += Mathf.Abs(killedZombieNumber);
    }
}
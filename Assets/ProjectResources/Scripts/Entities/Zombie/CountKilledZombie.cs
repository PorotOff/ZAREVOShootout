using System.IO;
using UnityEngine;

public class CountKilledZombie : MonoBehaviour
{
    private KilledZombie killedZombie;
    private JSONSaveLoad killedZombieJson;

    private void Awake()
    {
        string fileDirectory = Path.Combine(Application.persistentDataPath, "GameResources", "Saves");
        string fileName = "KilledZombieStatistic.json";
        killedZombieJson = new JSONSaveLoad(fileDirectory, fileName);

        killedZombie = killedZombieJson.Load<KilledZombie>();
    }

    private void OnEnable()
    {
        // Entity.OnEntityHealthZero.AddListener(Count);
    }
    private void OnDisable()
    {
        // Entity.OnEntityHealthZero.RemoveListener(Count);
    }

    private void Count()
    {
        killedZombie.AddKilledZombieNumber(1);

        killedZombieJson.Save(killedZombie);
    }
}
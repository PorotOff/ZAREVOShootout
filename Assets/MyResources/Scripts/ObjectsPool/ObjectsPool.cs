using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    private Transform objectsContainer;
    [SerializeField] private int objectsAmount;
    [SerializeField] private GameObject prefabToPoolAdding;

    private void Awake()
    {
        objectsContainer = GetComponent<Transform>();
    }

    private void Start()
    {
        FillPool();
    }

    private void FillPool() 
    {
        for(int i = 0; i < objectsAmount; i++)
        {
            GameObject poolObject = Instantiate(prefabToPoolAdding, objectsContainer);
            poolObject.gameObject.SetActive(false);
        }
    }
}

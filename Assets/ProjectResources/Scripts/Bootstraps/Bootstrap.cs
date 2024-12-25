using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnpoint;

    [Header("Camera settings")]
    [SerializeField] private CameraConfig cameraConfig;
    private DynamicCameraMovement dynamicCameraMovement;
    private Transform target;

    private void Awake()
    {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = playerSpawnpoint.position;

        dynamicCameraMovement = FindAnyObjectByType<DynamicCameraMovement>();
        target = player.transform;
        dynamicCameraMovement.Initialise(target, cameraConfig.smoothingRatio);
    }
}
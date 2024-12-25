using UnityEngine;

[CreateAssetMenu(fileName = "DynamicCameraSmoothingRatioConfig", menuName = "Configurations/Gameplay/DynamicCameraSmoothingRatioConfig")]
public class CameraConfig : ScriptableObject
{
    [field: SerializeField] public float smoothingRatio { get; private set; }
}
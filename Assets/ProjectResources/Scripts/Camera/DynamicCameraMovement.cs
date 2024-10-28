using UnityEngine;

public class DynamicCameraMovement : MonoBehaviour
{
	private Player player;

	[SerializeField] private float smoothingMovement = 0.1f;

	private void OnEnable()
	{
		Player.OnPlayerSpawned.AddListener(SetPlayer);
	}
	private void OnDisable()
	{
		Player.OnPlayerSpawned.RemoveListener(SetPlayer);
	}

	private void Update()
	{
		Vector3 targetPosition = player.transform.position;
		targetPosition.z = transform.position.z;

		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingMovement);
	}

	private void SetPlayer(Player player)
	{
		this.player = player;
	}
}

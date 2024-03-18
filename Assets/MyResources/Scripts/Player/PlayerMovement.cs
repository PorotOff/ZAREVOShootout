using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
	}

	private void FixedUpdate()
	{
		player.Move();
	}
}
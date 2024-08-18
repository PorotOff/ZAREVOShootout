using UnityEngine;

public class RandomMoveZombieOutOfBoundaries : MonoBehaviour
{
	private Zombie zombie;

	private void Awake()
	{
		zombie = GetComponent<Zombie>();
	}

	private void OnEnable()
	{
		gameObject.transform.position = RandomMoveZombie();
	}

	private Vector3 RandomMoveZombie()
	{
		Vector3 newSpawnPosition = Vector3.zero;
		// float zombieSize = zombie.GetComponent<SpriteRenderer>().bounds.size.magnitude;

		float newSpawnSide = CameraBoundaries.CameraBorders[Random.Range((int)CameraBoundaries.CameraSides.leftSide, (int)CameraBoundaries.CameraSides.bottomSide + 1)];

		float newSpawnPositionOnSide = Random.Range(CameraBoundaries.BottomCameraBorder, CameraBoundaries.TopCameraBorder);
		newSpawnPosition = GetNewSpawnPosition(newSpawnPosition, newSpawnSide, newSpawnPositionOnSide, transform.position.z);

		if (newSpawnSide == CameraBoundaries.TopCameraBorder || newSpawnSide == CameraBoundaries.BottomCameraBorder)
		{
			//it is Xpos
			newSpawnPositionOnSide = Random.Range(CameraBoundaries.LeftCameraBorder, CameraBoundaries.RightCameraBorder);
			newSpawnPosition = GetNewSpawnPosition(newSpawnPosition, newSpawnPositionOnSide, newSpawnSide, transform.position.z);
		}

		return newSpawnPosition;
	}

	private Vector3 GetNewSpawnPosition(Vector3 spawnPosition, float x, float y, float z)
	{
		spawnPosition.x = x;
		spawnPosition.y = y;
		spawnPosition.z = z;

		return spawnPosition;
	}
}
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsAfterGameStart : MonoBehaviour
{
	[SerializeField] private List<GameObject> objectsForHiddingAfterStartGame = new List<GameObject>();

	private void OnEnable()
    {
        NotifyStartGame.OnGameStarted.AddListener(DisableObjects);
    }
    private void OnDisable()
    {
        NotifyStartGame.OnGameStarted.RemoveListener(DisableObjects);
    }

	private void DisableObjects()
	{
		foreach (var objectForHidding in objectsForHiddingAfterStartGame)
		{
			objectForHidding.SetActive(false);
		}

		enabled = false;
	}
}
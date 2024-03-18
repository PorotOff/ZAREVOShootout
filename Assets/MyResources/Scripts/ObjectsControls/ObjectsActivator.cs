using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsActivator : MonoBehaviour
{
	private Transform objectsContainer;

	[Header("Activation settings")]
	[SerializeField] private bool isRandomTimeActivation = false;
	[SerializeField] private float activationDelay = 1f;

	private List<Coroutine> coroutines = new List<Coroutine>();

	private void Awake()
	{

	}

	private void OnValidate()
	{

	}

	private IEnumerator StandartActivateObjectsInPool()
	{
		while (true)
		{
			foreach (Transform childObject in objectsContainer)
			{
				if (!childObject.gameObject.activeInHierarchy)
				{
					childObject.gameObject.SetActive(true);

					break;
				}
			}

			yield return new WaitForSeconds(activationDelay);
		}
	}
}
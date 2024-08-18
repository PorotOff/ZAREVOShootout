using System.Collections;
using UnityEngine;

public class ObjectsActivator : MonoBehaviour
{
	private Transform objectsContainer;

	[Header("Activation settings")]
	[SerializeField] private bool isRandomTimeActivation = false;
	[SerializeField] private float activationDelay = 1f;
	[SerializeField] private float minActivationDelay = 0.3f;
	[SerializeField] private float maxActivationDelay = 3f;

	Coroutine currentCoroutine;

	private void Awake()
	{
		objectsContainer = GetComponent<Transform>();
	}

	private void OnEnable()
	{
		StartGameHandler.OnGameStarted.AddListener(StartWhichOneActivationCoroutine);

		GameOverHandler.OnGameOver.AddListener(StopCurrentCoroutine);
	}
	private void OnDisable()
	{
		StartGameHandler.OnGameStarted.RemoveListener(StartWhichOneActivationCoroutine);

		GameOverHandler.OnGameOver.RemoveListener(StopCurrentCoroutine);
	}

	private void StartWhichOneActivationCoroutine()
	{
		if (isRandomTimeActivation)
		{
			currentCoroutine = StartCoroutine(RandomObjectActivation());
		}
		else
		{
			currentCoroutine = StartCoroutine(StandartObjectActivation());
		}
	}
	private void StopCurrentCoroutine()
	{
		StopCoroutine(currentCoroutine);
	}

	private IEnumerator StandartObjectActivation()
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

	private IEnumerator RandomObjectActivation()
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

			float randomDelay = Random.Range(minActivationDelay, maxActivationDelay);
			yield return new WaitForSeconds(randomDelay);
		}
	}
}
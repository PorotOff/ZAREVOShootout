using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
	public static float LeftCameraBorder { get; private set; }
	public static float RightCameraBorder { get; private set; }
	public static float TopCameraBorder { get; private set; }
	public static float BottomCameraBorder { get; private set; }
	public static List<float> CameraBorders;

	private void Start()
	{
		DefineCameraBoundaries();

		CameraBorders = new List<float>()
		{
			LeftCameraBorder,
			RightCameraBorder,
			TopCameraBorder,
			BottomCameraBorder
		};
	}
	private void Update()
	{
		DefineCameraBoundaries();
	}

	public void DefineCameraBoundaries()
	{
		LeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
		RightCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
		TopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
		BottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
	}

	public enum CameraSides
	{
		leftSide,
		rightSide,
		topSide,
		bottomSide
	}
}
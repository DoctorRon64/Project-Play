using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private int ClickAmount = 3;
	[SerializeField] private float SystemDistance = 10f;

	[SerializeField] private GameObject HandLight;
	[SerializeField] private StarGeneratorManager StarGeneratorManager;
	[SerializeField] private Camera cam;
	private GameOver GameOverScript;

	private void Awake()
	{
		GameOverScript = GetComponent<GameOver>();
	}

	private void Update()
	{
		ClickDetect();
	}

	private void ClickDetect()
	{
		if (Input.GetMouseButtonDown(0) && (!GameOverScript.IsGameOver || !GameOverScript.IsGameWon))
		{
			ClickAmount--;
			if (Vector2.Distance(HandLight.transform.position, StarGeneratorManager.StarSystemInScene.transform.position) < SystemDistance)
			{
				GetComponent<GameOver>().IsGameWon = true;
			}
		}

		if (ClickAmount <= 0)
		{
			GetComponent<GameOver>().IsGameOver = true;
		}
	}
}
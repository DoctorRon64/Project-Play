using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private int ClickAmount = 3;
	[SerializeField] private float SystemDistance = 10f;

	[SerializeField] private GameObject HandLight;
	[SerializeField] private StarGeneratorManager StarGeneratorManager;
	[SerializeField] private Slider clickSlider;
	[SerializeField] private Camera cam;
	private bool theGameIsOver;
	private GameOver GameOverScript;

	private void Awake()
	{
		theGameIsOver = false;
		GameOverScript = GetComponent<GameOver>();
	}

	private void Update()
	{
		ClickDetect();
		clickSlider.value = ClickAmount;
	}

	private void ClickDetect()
	{
		if (Input.GetMouseButtonDown(0) && !theGameIsOver)
		{
			ClickAmount--;
			if (Vector2.Distance(HandLight.transform.position, StarGeneratorManager.StarSystemInScene.transform.position) < SystemDistance)
			{
				theGameIsOver = true;
				GameOverScript.IsGameWon = true;
			}
		}

		if (ClickAmount <= 0 && !theGameIsOver)
		{
			GameOverScript.IsGameOver = true;
			theGameIsOver = true;
		}
	}
}
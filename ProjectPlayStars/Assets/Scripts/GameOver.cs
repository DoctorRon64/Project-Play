using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[SerializeField] private GameObject GameOverScreen;
	[SerializeField] private GameObject GameOverText;
	[SerializeField] private GameObject GameWonText;
	[SerializeField] private HandMover LightMover;
	[SerializeField] private HandRotator HandMover;
	[SerializeField] private SoundManager SoundManager;

	public bool IsGameOver
	{
		set { if (value == true) { GameOverNow(); GameOverText.SetActive(true); } }
	}

	public bool IsGameWon
	{
		set { if (value == true) { GameOverNow(); GameWonText.SetActive(true); } }
	}

	private void Awake()
	{
		GameOverScreen.SetActive(false);
		GameWonText.SetActive(false);
		GameOverText.SetActive(false);
	}

	private void GameOverNow()
	{
		Cursor.visible = true;
		GameOverScreen.SetActive(true);
		LightMover.enabled = false;
		HandMover.enabled = false;
		SoundManager.enabled = false;
	}
}

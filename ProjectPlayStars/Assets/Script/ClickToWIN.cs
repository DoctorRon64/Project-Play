using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToWIN : MonoBehaviour
{
	public int isWinning;

	private void OnMouseDown()
	{
		isWinning = 1;
	}
}

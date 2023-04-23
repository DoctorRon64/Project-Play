using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GetIfCloseToSystem : MonoBehaviour
{
	[SerializeField] private HandMover flashLight;
	[SerializeField] private StarGeneratorManager starGenerator;
	[SerializeField] private float InRangeDistance = 10f;
	[SerializeField] private float OutRangeDistance = 50f;
	private GameObject starSystemInScene;

	[SerializeField] private Color greenColor = new Color(0, 1, 0, 1);
	[SerializeField] private Color redColor = new Color(1, 0, 0, 1);
	[SerializeField] private Color whiteColor = new Color(1, 1, 1, 1);


	private void LateUpdate()
	{
		CheckDistance();
	}

	private void CheckDistance()
	{
		starSystemInScene = starGenerator.StarSystemInScene;
		if (Vector3.Distance(flashLight.transform.position, starSystemInScene.transform.position) < InRangeDistance)
		{

			for (int i = 0; i < starGenerator.StarList.Count; i++)
			{
				MakeColor(greenColor, i);
			}
		}
		else if (Vector3.Distance(flashLight.transform.position, starSystemInScene.transform.position) > OutRangeDistance)
		{
			for (int i = 0; i < starGenerator.StarList.Count; i++)
			{
				MakeColor(redColor, i);
			}
		}
		else
		{
			for (int i = 0; i < starGenerator.StarList.Count; i++)
			{
				MakeColor(whiteColor, i);
			}
		}
	}

	void MakeColor(Color color, int _index)
	{
		starGenerator.StarList[_index].GetComponent<Light2D>().color = color;
		starGenerator.StarList[_index].GetComponentInChildren<SpriteRenderer>().color = color;
	}
}

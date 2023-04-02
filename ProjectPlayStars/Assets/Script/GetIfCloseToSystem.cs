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
				starGenerator.StarList[i].GetComponent<Light2D>().color = Color.green;
			}
		} 
		else if (Vector3.Distance(flashLight.transform.position, starSystemInScene.transform.position) > OutRangeDistance)
		{
			for (int i = 0; i < starGenerator.StarList.Count; i++)
			{
				starGenerator.StarList[i].GetComponent<Light2D>().color = Color.red;
			}
		}
		else
		{
			for (int i = 0; i < starGenerator.StarList.Count; i++)
			{
				starGenerator.StarList[i].GetComponent<Light2D>().color = Color.white;
			}
		}
	}
}

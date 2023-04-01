using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGeneratorManager : MonoBehaviour
{
    [SerializeField] private int GridWidth;
    [SerializeField] private int GridHeight;
    [SerializeField] private int StarAmount;

	[SerializeField] private GameObject Star;
	[SerializeField] private GameObject StarFolder;

	[SerializeField] private float StarScaleMin;
	[SerializeField] private float StarScaleMax;

	private List<GameObject> prefabStars = new List<GameObject>();

	private void Awake()
	{
		GenerateGrid();
	}

	[ContextMenu("Generate")]
	private void GenerateGrid()
	{
		ClearStarsInGrid();

		for (int i = 0; i < StarAmount; i++)
		{
			GenerateStarInGrid(Star, prefabStars);
		}
	}

	private void GenerateStarInGrid(GameObject _PrefabObj, List<GameObject> _list)
	{
		Vector2 _positon = new Vector2(Random.Range(-GridWidth, GridWidth), Random.Range(-GridHeight, GridHeight));
		GameObject _InstantiateObject = Instantiate(_PrefabObj, _positon, Quaternion.identity, StarFolder.transform);
		_InstantiateObject.transform.localScale = new Vector3(Random.Range(StarScaleMin, StarScaleMax), Random.Range(StarScaleMin, StarScaleMax), 1f);
		_list.Add(_InstantiateObject);
	}

	[ContextMenu("Clear")]
	private void ClearStarsInGrid()
	{
		if (prefabStars.Count <= 0) { return; }

		Debug.Log("clear");

		for (int i = 0; i < StarAmount; i++)
		{ 
			DestroyImmediate(prefabStars[i]);
		}
		prefabStars.Clear();
	}
}

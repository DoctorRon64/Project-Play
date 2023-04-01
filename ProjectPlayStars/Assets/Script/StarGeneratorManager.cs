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

	[SerializeField] private List<GameObject> StarSystemPrefabs = new List<GameObject>();
	[SerializeField] private List<string> StarSystemPrefabsNames = new List<string>();
	private List<GameObject> StarList = new List<GameObject>();

	private Dictionary<string, List<GameObject>> StarSystems = new Dictionary<string, List<GameObject>>();

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
			GenerateStarInGrid(Star, StarList);
		}
	}

	private void GenerateStarInGrid(GameObject _PrefabObj, List<GameObject> _list)
	{
		Vector2 _positon = new Vector2(Random.Range(-GridWidth, GridWidth), Random.Range(-GridHeight, GridHeight));
		GameObject _InstantiateObject = Instantiate(_PrefabObj, _positon, Quaternion.identity, StarFolder.transform);
		float _randomScale = Random.Range(StarScaleMin, StarScaleMax);
		_InstantiateObject.transform.localScale = new Vector3(_randomScale, _randomScale, 1f);
		_list.Add(_InstantiateObject);
	}

	[ContextMenu("Clear")]
	private void ClearStarsInGrid()
	{
		for (int i = StarList.Count - 1; i >= 0; i--)
		{ 
			DestroyImmediate(StarList[i]);
		}

		for (int i = 0; i < StarList.Count; i++)
		{
			Destroy(StarList[i]);
		}

		StarList.Clear();
	}

	private void SetStarSystem()
	{
		for (int i = 0; i < 12; i++)
		{
			StarSystems.Add(StarSystemPrefabsNames[i], StarSystemPrefabs[i]);
		}
	}
}

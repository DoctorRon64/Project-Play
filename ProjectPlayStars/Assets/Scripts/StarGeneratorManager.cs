using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StarGeneratorManager : MonoBehaviour
{
	//settings
    [SerializeField] private int GridWidth;
    [SerializeField] private int GridHeight;
    [SerializeField] private int StarAmount;

	[SerializeField] private GameObject Star;
	[SerializeField] private GameObject StarFolder;

	[SerializeField] private float StarScaleMin;
	[SerializeField] private float StarScaleMax;

	[SerializeField] private List<GameObject> Probes = new List<GameObject>();
	[SerializeField] private int ProbeAmount;

	public List<GameObject> StarList = new List<GameObject>();
	public List<GameObject> ProbesList = new List<GameObject>();

	private void Awake()
	{
		GenerateGrid();
	}

	[ContextMenu("Generate")]
	private void GenerateGrid()
	{
		ClearStarsInGrid();

		for (int i = 0; i < ProbeAmount; i++)
		{
			GenerateStarSystemInGrid(Probes[Random.Range(0, Probes.Count)]);
		}

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

		if (_randomScale >= (StarScaleMax / 2)) { _randomScale = Random.Range(StarScaleMin, StarScaleMax); }
		_InstantiateObject.GetComponent<Light2D>().pointLightOuterRadius = _randomScale;

		_InstantiateObject.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(_randomScale / 25, _randomScale / 25, 0f);
		_list.Add(_InstantiateObject);
	}

	private void GenerateStarSystemInGrid(GameObject _PrefabObj)
	{
		Vector2 _position = new Vector2(Random.Range(-GridWidth, GridWidth), Random.Range(-GridHeight, GridHeight));
		GameObject ProbeAdded = Instantiate(_PrefabObj, _position, Quaternion.identity, StarFolder.transform);
		ProbesList.Add(ProbeAdded);
	}

	[ContextMenu("Clear")]
	private void ClearStarsInGrid()
	{
		for(int i = 0; i < ProbesList.Count; i++)
		{
			DestroyImmediate(ProbesList[i]);
		}
 
		for (int i = StarList.Count - 1; i >= 0; i--)
		{ 
			DestroyImmediate(StarList[i]);
		}

		for (int i = 0; i < StarList.Count; i++)
		{
			Destroy(StarList[i]);
		}

		ProbesList.Clear();
		StarList.Clear();
	}
}

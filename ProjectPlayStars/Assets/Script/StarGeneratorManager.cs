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

	[SerializeField] private List<GameObject> StarSystemPrefabs = new List<GameObject>();

	//=================================================================

	//in scene
	public List<GameObject> StarList = new List<GameObject>();
	public GameObject StarSystemInScene;
	public Dictionary<string, GameObject> StarSystems = new Dictionary<string, GameObject>();

	private void Awake()
	{
		GenerateGrid();
	}

	[ContextMenu("Generate")]
	private void GenerateGrid()
	{
		ClearStarsInGrid();
		GenerateStarSystemInGrid(StarSystemPrefabs[Random.Range(0, StarSystemPrefabs.Count)]);

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
		_list.Add(_InstantiateObject);
	}

	private void GenerateStarSystemInGrid(GameObject _PrefabObj)
	{
		Vector2 _position = new Vector2(Random.Range(-GridWidth, GridWidth), Random.Range(-GridHeight, GridHeight));
		StarSystemInScene = Instantiate(_PrefabObj, _position, Quaternion.identity, StarFolder.transform);
		StarSystems.Add(_PrefabObj.name, _PrefabObj);

		StarSystem _system = StarSystemInScene.GetComponent<StarSystem>();

		for (int i = 0; i < _system.Stars.Count; i++)
		{
			GameObject _StarInstantiateObject = Instantiate(Star, new Vector3(_system.Stars[i].x + StarSystemInScene.transform.position.x, _system.Stars[i].y + StarSystemInScene.transform.position.y, 0f), Quaternion.identity, StarSystemInScene.transform);
			
			float _randomScale = Random.Range(StarScaleMin, StarScaleMax);
			if (_randomScale >= (StarScaleMax / 2)) { _randomScale = Random.Range(StarScaleMin, StarScaleMax); }

			_StarInstantiateObject.GetComponent<CircleCollider2D>().radius = 0.1f;
			_StarInstantiateObject.GetComponent<Light2D>().pointLightOuterRadius = _randomScale;

			StarList.Add(_StarInstantiateObject);
		}
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

		DestroyImmediate(FindObjectOfType<StarSystem>());
		StarSystems.Clear();
		StarList.Clear();
	}
}

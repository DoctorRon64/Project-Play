using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StarGeneratorManager : MonoBehaviour
{
    // Settings
    [SerializeField] private int GridWidth;
    [SerializeField] private int GridHeight;
    [SerializeField] private int StarAmount;

    [SerializeField] private GameObject Star;
    [SerializeField] private GameObject StarFolder;

    [SerializeField] private float StarScaleMin;
    [SerializeField] private float StarScaleMax;

    [SerializeField] private List<GameObject> Probes = new List<GameObject>();
    [SerializeField] private int ProbeAmount;

    public StarGeneratorData generatorData; // Reference to the ScriptableObject

    [SerializeField] private Collider2D spawnCollider;
    [SerializeField] private Collider2D spawnProbeCollider;

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
            GenerateStarInGrid(Star, generatorData.StarList);
        }
    }

    private void GenerateStarInGrid(GameObject _PrefabObj, List<GameObject> _list)
    {
        Vector2 _positon = GetRandomPositionInCollider(spawnCollider);
        GameObject _InstantiateObject = Instantiate(_PrefabObj, _positon, Quaternion.identity, StarFolder.transform);

        float _randomScale = Random.Range(StarScaleMin, StarScaleMax);

        if (_randomScale >= (StarScaleMax / 2)) { _randomScale = Random.Range(StarScaleMin, StarScaleMax); }
        _InstantiateObject.GetComponent<Light2D>().pointLightOuterRadius = _randomScale;

        _InstantiateObject.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(_randomScale / 25, _randomScale / 25, 0f);
        _list.Add(_InstantiateObject);
    }

    private void GenerateStarSystemInGrid(GameObject _PrefabObj)
    {
        Vector2 _position = GetRandomPositionInCollider(spawnProbeCollider);
        GameObject ProbeAdded = Instantiate(_PrefabObj, _position, Quaternion.identity, StarFolder.transform);
        ProbeAdded.tag = "RealProbes";
        ProbeAdded.AddComponent<RealProbes>();
        ProbeAdded.GetComponentInChildren<SpriteRenderer>().enabled = false;
        generatorData.RealProbesList.Add(ProbeAdded);
        generatorData.ProbesList.Add(ProbeAdded);
    }

    private Vector2 GetRandomPositionInCollider(Collider2D _collider2D)
    {
        if (spawnCollider == null)
        {
            Debug.LogError("Spawn collider not assigned!");
            return Vector2.zero;
        }

        Vector2 randomPoint;
        int maxAttempts = 100;
        for (int i = 0; i < maxAttempts; i++)
        {
            randomPoint = new Vector2(Random.Range(-GridWidth, GridWidth), Random.Range(-GridHeight, GridHeight));
            if (_collider2D.OverlapPoint(randomPoint))
            {
                return randomPoint;
            }
        }

        Debug.LogWarning("Could not find a valid position inside the collider after " + maxAttempts + " attempts. Returning zero vector.");
        return Vector2.zero;
    }

    [ContextMenu("Clear")]
    private void ClearStarsInGrid()
    {
        for (int i = 0; i < generatorData.ProbesList.Count; i++)
        {
            DestroyImmediate(generatorData.ProbesList[i]);
        }

        for (int i = 0; i < generatorData.RealProbesList.Count; i++)
        {
            DestroyImmediate(generatorData.RealProbesList[i]);
        }

        for (int i = generatorData.StarList.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(generatorData.StarList[i]);
        }

        for (int i = 0; i < generatorData.StarList.Count; i++)
        {
            Destroy(generatorData.StarList[i]);
        }

        generatorData.RealProbesList.Clear();
        generatorData.ProbesList.Clear();
        generatorData.StarList.Clear();
    }
}

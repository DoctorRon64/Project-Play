using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMaker : MonoBehaviour
{
    [SerializeField] private StarGeneratorData generatorData;
    [SerializeField] private GameObject parentTransform;
    [SerializeField] private Vector3 offsetScale = new Vector3(0.5f, 0.5f, 0);
    [SerializeField] private Vector3 offsetPosition = new Vector3(0.5f, 0.5f, 0);
    [SerializeField] private Vector3 pivotOffset = Vector3.zero;

    public List<GameObject> realProbes = new List<GameObject>();

    private void Start()
    {
        GenerateProbes();
    }

    private void GenerateProbes()
    {
        foreach (GameObject probePrefab in generatorData.RealProbesList)
        {
            GameObject instantiatedProbe = Instantiate(probePrefab, parentTransform.transform);
            instantiatedProbe.layer = 6;
            instantiatedProbe.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);
            instantiatedProbe.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            instantiatedProbe.tag = "Untagged";
            Destroy(instantiatedProbe.GetComponent<RealProbes>());
            Destroy(instantiatedProbe.GetComponentInChildren<TwinkleProbeScript>());
            realProbes.Add(instantiatedProbe);
        }
    }

    private void Update()
    {
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        parentTransform.transform.localScale = offsetScale;
        parentTransform.transform.localPosition = offsetPosition;

        foreach (GameObject probe in realProbes)
        {
            probe.transform.localPosition += pivotOffset;
        }
    }
}

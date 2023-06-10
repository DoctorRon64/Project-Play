using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMaker : MonoBehaviour
{
    [SerializeField] private StarGeneratorManager starmgr;
    [SerializeField] private GameObject ParentTransform;
    private List<GameObject> RealProbes = new List<GameObject>();
    [SerializeField] private Vector3 offsetScale = new Vector3(0.5f, 0.5f, 0);
    [SerializeField] private Vector3 offsetPosition = new Vector3(0.5f, 0.5f, 0);
    [SerializeField] private LayerMask hitLayer;

    private void Start()
    {
        for (int i = 0; i < starmgr.RealProbesList.Count; i++)
        {
            GameObject instant = Instantiate(starmgr.RealProbesList[i]);

            instant.layer = 6;
            instant.transform.parent = ParentTransform.transform;
            instant.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);
            RealProbes.Add(instant);
        }
    }

    private void Update()
    {
        ParentTransform.transform.localScale = offsetScale;
        ParentTransform.transform.localPosition = offsetPosition;
    }


}


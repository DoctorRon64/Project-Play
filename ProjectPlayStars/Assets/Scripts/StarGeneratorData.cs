using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StarGeneratorData", order = 1)]
public class StarGeneratorData : ScriptableObject
{
    public List<GameObject> StarList = new List<GameObject>();
    public List<GameObject> RealProbesList = new List<GameObject>();
    public List<GameObject> ProbesList = new List<GameObject>();
}

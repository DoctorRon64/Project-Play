using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour
{
    public int StartingStarAmount;
    private int StarAmount;
    public float XYmin;
    public GameObject[] prefabObj;
    public List<GameObject> prefabList = new();
    public UnityEngine.Color colouer;

    public Sprite[] ConstellationImg = new Sprite[12];
    public GameObject[] Constellation = new GameObject[12];
    public float ConstellationAngle;
    public int pickstarconstellation;
    public Transform RevealConstellation;
    public Transform ObjToWin;

    public Image CompassImg;

    public Transform LibraryFolder;

    public float TwinkleSettingSpeed;
    public float TwinkleIntensity;
    public RuntimeAnimatorController[] anim = new RuntimeAnimatorController[4];

    private void Start()
	{
        StarAmount = StartingStarAmount;
        for (int i = 0; StarAmount > i; i++)
        {
            int x = Random.Range(0, prefabObj.Length);
            Vector2 location = new Vector2(Random.Range(XYmin, -XYmin), Random.Range(XYmin, -XYmin));
            GameObject instantiatePrefabObject;
            instantiatePrefabObject = Instantiate(prefabObj[x], location, Quaternion.identity);
            instantiatePrefabObject.GetComponent<Light2D>().pointLightOuterRadius = Random.Range(0.1f, 0.5f);
            prefabList.Add(instantiatePrefabObject);
        }
        pickstarconstellation = Random.Range(0, 12);
        AddConstillation();
        ScaleAndColorRand();
        TwinkleTwinkle();
    }

	void AddConstillation()
	{
        float f = Random.Range(0, 1);
        float p = Random.Range(0, 1);
		float x = Random.Range(8, 20);
		float y = Random.Range(8, 20);
        if (f == 0)
		{
            x *= - 1;
		}
        if (p == 0)
		{
            y *= -1;
		}

		ConstellationAngle = Mathf.Cos(y / x);
		Debug.Log(ConstellationAngle);

		Vector2 location = new Vector2(x, y);
		GameObject instantiatePrefabObject;
		instantiatePrefabObject = Instantiate(Constellation[pickstarconstellation], location, Quaternion.identity);
		instantiatePrefabObject.transform.SetParent(LibraryFolder);

		RevealConstellation = instantiatePrefabObject.transform.GetChild(0);
        UnityEngine.Color colouers = new UnityEngine.Color(1, 1, 1, 0.01f);
        CompassImg.sprite = RevealConstellation.GetComponent<SpriteRenderer>().sprite;
        CompassImg.rectTransform.rotation = instantiatePrefabObject.transform.rotation;
        RevealConstellation.GetComponent<SpriteRenderer>().color = colouers;
        ObjToWin = instantiatePrefabObject.transform;
    }

	void ScaleAndColorRand()
    {
        for (int i = 0; i < prefabList.Count; i++)
        {
            colouer = new UnityEngine.Color(1f, Random.Range(1, 0.5f), Random.Range(0.3f,1), 1);
            prefabList[i].GetComponent<Light2D>().color = colouer;
            prefabList[i].transform.SetParent(LibraryFolder);
            prefabList[i].GetComponent<Transform>().localScale = new Vector2(1,1);
        }
        
    }

	private void Update()
	{
    }

	void TwinkleTwinkle()
	{
		for (int i = 0; i < prefabList.Count; i++)
		{
            prefabList[i].GetComponent<Animator>().runtimeAnimatorController = anim[Random.Range(0, 4)];
		}
	}
}

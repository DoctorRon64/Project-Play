using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectPrefabs = new List<GameObject>();
    [SerializeField] private StarGeneratorData generatorData;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject infiniteLooper;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private WinManager wnMgr;
    [SerializeField] private Sprite RImage;
    [SerializeField] private Sprite GImage;
    [SerializeField] private float speed = 20f;

    private bool canShoot = true;
    private Vector3 landingPosition;

	private void Awake()
	{
        spriteRenderer.sprite = RImage;
    }

    private void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObject();
        }
    }

    public void ThrowObject()
    {
        GameObject obj = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Count)], spawnPoint.position, Quaternion.identity);

        generatorData.ProbesList.Add(obj);
        obj.AddComponent<Probes>();

        landingPosition.x = obj.transform.position.x;
        landingPosition.y = infiniteLooper.transform.position.y;
        obj.GetComponent<Probes>().SetTargetPosition(landingPosition);
        obj.GetComponent<Probes>().setSpeed(speed);
        obj.GetComponent<Probes>().Parent = Parent;
        obj.GetComponent<Probes>().wnMgr = wnMgr;
        obj.GetComponent<Probes>().starData = generatorData;

        canShoot = false;
        spriteRenderer.sprite = GImage;
    }

    public void EnableShooting()
    {
        canShoot = true;
        spriteRenderer.sprite = RImage;
    }

    public Vector3 GetLandingPosition()
    {
        return landingPosition;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectPrefabs = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform Parent;

    private float timer = 0f;
    private bool isIncreasing = true;
    [SerializeField] private float minSpeed = 5f;
    [SerializeField] private float maxSpeed = 20f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObject();
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        float speedRange = maxSpeed - minSpeed;
        float timerDirection = isIncreasing ? 1f : -1f;

        timer += timerDirection * Time.deltaTime;

        if (timer <= 0f || timer >= 1f)
        {
            isIncreasing = !isIncreasing;
        }

        float currentSpeed = minSpeed + timer * speedRange;
    }

    public void ThrowObject()
    {
        GameObject obj = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Count)], spawnPoint.position, Quaternion.identity);
        obj.AddComponent<Probes>();
        obj.GetComponent<Probes>().initialSpeed = GetSpeedBasedOnTimer();
        obj.GetComponent<Probes>().Parent = Parent;
    }

    private float GetSpeedBasedOnTimer()
    {
        float speedRange = maxSpeed - minSpeed;
        float currentSpeed = minSpeed + timer * speedRange;
        return currentSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class TwinkleProbeScript : MonoBehaviour
{
    private Light2D parentLight;

	private void Awake()
	{
        parentLight = GetComponent<Light2D>();
        parentLight.intensity = 7f;
    }

	private void Update()
    {
        Twinkle();
    }

    private void Twinkle()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue < 1)
        {
            float rotationDuration = Random.Range(1f, 3f); // random duration for rotation
            StartCoroutine(RotateForDuration(rotationDuration));

            parentLight.intensity = Random.Range(5, 10f);
            if (parentLight.intensity > 4f) { parentLight.intensity = Random.Range(5, 7f); }
        }
    }

    private IEnumerator RotateForDuration(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        parentLight.intensity = Random.Range(5, 10f);
    }
}

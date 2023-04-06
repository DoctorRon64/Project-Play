using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class TwinkleScript : MonoBehaviour
{
    private SpriteRenderer sprtRndr;
    private Light2D parentLight;
    private bool isRotating = false;

	private void Awake()
	{
		sprtRndr = GetComponent<SpriteRenderer>();
        parentLight = gameObject.transform.parent.GetComponent<Light2D>();
        parentLight.intensity = 7f;
        SetOpacity(0f);
    }

	private void Update()
    {
        Twinkle();
    }

    private void Twinkle()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue < 1 && !isRotating)
        {
            isRotating = true;
            float rotationDuration = Random.Range(1f, 3f); // random duration for rotation
            StartCoroutine(RotateForDuration(rotationDuration));

            parentLight.intensity = Random.Range(0, 7f);
            if (parentLight.intensity > 4f) { parentLight.intensity = Random.Range(0, 7f); }
        }
    }

    private IEnumerator RotateForDuration(float duration)
    {
        float elapsed = 0f;
        float speed = Random.Range(1f, 30f); // random rotation speed

        while (elapsed < duration)
        {
            float _RandomColorOpacity = Random.Range(60, 90) / 100f;
            
            SetOpacity(_RandomColorOpacity);

            float angle = elapsed * speed;
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            elapsed += Time.deltaTime;
            yield return null;
        }

        SetOpacity(0f);
        parentLight.intensity = Random.Range(0, 7f);
        isRotating = false;
    }

    private void SetOpacity(float opacity)
    {
        Color color = sprtRndr.color;
        color.a = opacity;
        sprtRndr.color = color;
    }
}

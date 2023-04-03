using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class TwinkleScript : MonoBehaviour
{
	private GameObject pictureObject;

    public bool rotateX = true;
    private float rotationSpeed;
    public float ScaleSign;
    private float rotz;

    private void Awake()
	{
		pictureObject = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    private void Update()
    {
        Twinkle();
    }

    private void Twinkle()
	{
        if (rotateX == true)
        {
            rotz += Time.deltaTime * rotationSpeed;

            if (rotz > 180.0f)
            {
                rotz = 0.0f;
                rotateX = false;
            }

            pictureObject.transform.rotation = Quaternion.Euler(90.0f, 0, rotz);
        }

        float _random = Random.Range(0f, 1000f);

        if (_random < 1)
        {
            rotateX = true;
        }
    }
}

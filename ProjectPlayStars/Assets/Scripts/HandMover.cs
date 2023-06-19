using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandMover : MonoBehaviour
{
    public float speed = 10f;
    public float offsetY = 0.1f;

    [SerializeField] private Camera cam;

    private float mouseX;
    private float mouseY;

	private void Awake()
	{
		Cursor.visible = false;
	}

	void Update()
    {
        FlickerActivate();
        MouseFollow();
    }

    void MouseFollow()
	{
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 10));
        Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y + offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }

    void FlickerActivate()
	{
        int Timer = Random.Range(0, 100);

        if (Timer <= 1)
		{
            Flicker();
		}
        else
		{
            GetComponent<Light2D>().intensity = 5;
        }
    }

    void Flicker()
	{
        for (int i = 0; i < 10; i++)
		{
            GetComponent<Light2D>().intensity = Random.Range(0, 6f);
        }
    }
}

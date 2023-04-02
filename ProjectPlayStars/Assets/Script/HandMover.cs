using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 10));
        Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y + offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}

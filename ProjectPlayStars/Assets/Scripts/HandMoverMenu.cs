using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMoverMenu : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Vector2 mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePos, speed);
    }
}

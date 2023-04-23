using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotator : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public float rotationSpeed = 10f; // Speed of rotation
    public float minRotationAngle = -45f; // Minimum rotation angle in degrees
    public float maxRotationAngle = 45f; // Maximum rotation angle in degrees
    public float rotationOffset = 0f; // Rotation offset in degrees

    private Vector3 target;

    void Update()
    {
        PointToFlash();
    }

    void PointToFlash()
    {
        // Get the position of the mouse in 2D space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - cam.transform.position.z;

        target = cam.ScreenToWorldPoint(mousePos);
        Vector3 direction = target - transform.position;

        float angle = Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, minRotationAngle, maxRotationAngle) + rotationOffset;

        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

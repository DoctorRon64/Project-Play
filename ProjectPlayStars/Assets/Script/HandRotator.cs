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
    public float stoppingDistance = 10f; // Distance to stop from the mouse
    public float moveBackSpeed = 5f; // Speed to move back when the mouse gets close
    public float returnSpeed = 5f; // Speed to return to original position
    public float smoothingFactor = 10f; // Smoothing factor for lerping back to original position

    private Vector2 currentPos;
    private Quaternion currentRotation;
    private Vector3 target;

    private bool isMovingBack = false;

    private void Awake()
    {
        currentPos = transform.position;
        currentRotation = transform.rotation;
    }

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

        if (Vector3.Distance(target, transform.position) < stoppingDistance)
        {
            // Move back
            isMovingBack = true;
        }
        else
        {
            // Save the current rotation when not moving back
            currentRotation = transform.rotation;
            isMovingBack = false;
        }

        if (!isMovingBack && Vector3.Distance(transform.position, currentPos) > 0.1f)
        {
            // Return to original position
            Vector3 moveDirection = ((Vector3)currentPos - transform.position).normalized;
            transform.position = Vector3.Lerp(transform.position, currentPos, Time.deltaTime * smoothingFactor);
        }
    }

    private void FixedUpdate()
    {
        // Reset the rotation after moving back
        if (Vector3.Distance(transform.position, currentPos) < 0.1f)
        {
            transform.rotation = currentRotation;
        }

        if (isMovingBack)
        {
            Vector3 moveDirection = (transform.position - target).normalized;
            transform.position += moveDirection * moveBackSpeed * Time.deltaTime;
        }
    }   
}

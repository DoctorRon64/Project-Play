using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandMoverMenu : MonoBehaviour
{
    public Transform[] pathPoints; // An array of transforms that define the path the object should follow
    public float moveSpeed = 5f; // The speed at which the object moves along the path
    public Camera cam;

    private int currentPathIndex = 0; // The current index of the path point the object is moving towards

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Distance from camera
        Vector3 targetPosition = cam.ScreenToWorldPoint(mousePosition);

        // Get the direction and distance to the next path point
        Vector3 direction = (pathPoints[currentPathIndex].position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, pathPoints[currentPathIndex].position);

        // Check if the object has reached the current path point and move towards the next point if it has
        if (distance < 0.1f)
        {
            currentPathIndex = (currentPathIndex + 1) % pathPoints.Length;
        }
        else
        {
            // Move the object towards the current path point
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Move the object towards the mouse position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }
}

using UnityEngine;

public class InfiniteLooper : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float topBoundary = 10f;
    [SerializeField] private float bottomBoundary = -10f;
    [SerializeField] private ObjectShooter objectShooter;

    private bool reachedLandingPosition = false;


	private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.y >= topBoundary)
        {
            TeleportToBottom();
            reachedLandingPosition = false;
            objectShooter.EnableShooting();
        }

        if (!reachedLandingPosition && Mathf.Approximately(transform.position.y, objectShooter.GetLandingPosition().y))
        {
            reachedLandingPosition = true;
        }
    }

    private void TeleportToBottom()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = bottomBoundary;
        transform.position = newPosition;
    }
}

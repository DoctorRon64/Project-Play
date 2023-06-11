using UnityEngine;

public class Probes : MonoBehaviour
{
    private Vector3 landingPosition;
    private float speed;
    private float smoothness = 0.1f;
    public Transform Parent;
    private GameObject ModelChild;
    public StarGeneratorData starData;

    private bool isMoving;
    private float movementTimer;

    void Start()
    {
        transform.SetParent(Parent);
        ModelChild = transform.GetChild(0).gameObject;
        gameObject.tag = "Probes";
    }

    void Update()
    {
        if (isMoving)
        {
            ModelChild.transform.Rotate(Vector3.forward, Random.Range(0f, 360f) * Time.deltaTime);

            float step = speed * Time.deltaTime;
            Vector3 newPosition = transform.position;
            newPosition.y = Mathf.Lerp(newPosition.y, landingPosition.y, smoothness * step);
            transform.position = newPosition;

            movementTimer += Time.deltaTime;
            if (movementTimer >= 1f)
            {
                isMoving = false;
                checkIfCollidingWithRealProbe();
            }

            if (Mathf.Abs(transform.position.y - landingPosition.y) < 1f)
            {
                isMoving = false;
                checkIfCollidingWithRealProbe();
            }
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        landingPosition = targetPosition;
        isMoving = true;
        movementTimer = 0f;
        Debug.Log(targetPosition);
    }

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    private void checkIfCollidingWithRealProbe()
    {
        for (int i = 0; i < starData.RealProbesList.Count; i++)
        {
            GameObject realProbe = starData.RealProbesList[i];
            if (realProbe.CompareTag("RealProbe") && gameObject.CompareTag("Probes") && realProbe.GetComponent<Collider2D>().bounds.Intersects(GetComponent<Collider>().bounds))
            {
                Debug.Log("Colliding with Real Probe: " + realProbe.name);
            } else
			{
                Debug.Log(" NOt collided");
			}
        }
    }
}

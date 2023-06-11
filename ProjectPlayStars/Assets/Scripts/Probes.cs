using UnityEngine;

public class Probes : MonoBehaviour
{
    private Vector3 landingPosition;
    private float speed;
    private float smoothness = 0.1f;
    public Transform Parent;
    private GameObject ModelChild;
    public StarGeneratorData starData;
    public WinManager wnMgr;

    private bool isMoving;
    private float movementTimer;
    private bool activateOnce = true;

    private Vector3 initialScale;
    public float otherscale = 0.5f;

    void Start()
    {
        transform.SetParent(Parent);
        ModelChild = transform.GetChild(0).gameObject;
        gameObject.tag = "Probes";

        initialScale = transform.localScale;
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
                wnMgr.Feedback(0);
            }

            if (Mathf.Abs(transform.position.y - landingPosition.y) < 1f)
            {
                isMoving = false;
                wnMgr.Feedback(0);
            }

            float scalingFactor = 1f;
            if (transform.position.y >= 0f)
            {
                scalingFactor = 1f - (transform.position.y - Parent.position.y) / (landingPosition.y - Parent.position.y) * otherscale;
                scalingFactor = Mathf.Clamp01(scalingFactor);
            }

            transform.localScale = initialScale * scalingFactor;
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        landingPosition = targetPosition;
        isMoving = true;
        movementTimer = 0f;
    }

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RealProbes") && !isMoving && activateOnce)
        {
            GameObject collidedProbe = collision.gameObject;
            wnMgr.MiniMapUpdate(collidedProbe);
            collidedProbe.GetComponent<RealProbes>().Captured = true;
            wnMgr.CheckIfWon();
            wnMgr.Feedback(1);
            activateOnce = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probes : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float lifespan = 5f;
    public float deceleration = 2f;
    public Transform Parent;
    public Vector2 direction = Vector2.up;

    private GameObject ModelChild;
    private float elapsedTime = 0f;
    private Vector2 velocity;
    private bool isDead = false;

    void Start()
    {
        transform.SetParent(Parent);
        ModelChild = transform.GetChild(0).gameObject;
        velocity = initialSpeed * direction.normalized;
    }

    void Update()
    {
        if (!isDead)
        {
            transform.Translate(velocity * Time.deltaTime);

            velocity -= velocity.normalized * deceleration * Time.deltaTime;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= lifespan)
            {
                isDead = true;
            }

            if (ModelChild != null)
            {
                ModelChild.transform.Rotate(Vector3.forward, Random.Range(0f, 360f) * Time.deltaTime);
            }
        }
    }
}

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

    private float elapsedTime = 0f;
    private Vector2 velocity;
    private bool isDead = false;

    void Start()
    {
        transform.SetParent(Parent);
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
        }
    }

}

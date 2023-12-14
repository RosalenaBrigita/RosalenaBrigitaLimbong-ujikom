using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public float speed = 300f;
    public int hungerValue = 25;
    public float lifetime = 3f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * speed);
        }

        Destroy(gameObject, lifetime);
    }

    
}

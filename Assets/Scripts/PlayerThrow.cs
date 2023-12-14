using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject objectToThrow;
    public Transform throwTrasform;
    public float throwForce = 10f;

    public Animation animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        if (objectToThrow != null)
        {
            GameObject thrownObject = Instantiate(objectToThrow, throwTrasform.position, throwTrasform.rotation);

            Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(throwTrasform.forward * throwForce, ForceMode.Impulse);
            }
        }
    }
}

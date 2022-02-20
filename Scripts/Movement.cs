using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;


    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotationDir)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDir * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

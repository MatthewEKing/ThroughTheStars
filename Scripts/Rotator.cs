using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 rotateVector;

    void Update()
    {
        transform.Rotate(rotateVector * rotateSpeed * Time.deltaTime);
    }
}

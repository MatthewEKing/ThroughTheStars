using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [Range(0,1)] float movementFactor;

    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // coninually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // returns a value between -1 and 1

        //Debug.Log(rawSinWave);

        movementFactor = (rawSinWave + 1f) / 2; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}

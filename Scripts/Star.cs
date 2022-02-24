using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    StarManager starManager;
    LineRenderer lineRenderer;

    public bool connected = false;
    Vector3[] positions;

    void Start()
    {
        // Set Array For Line Renderer Positions
        positions = new Vector3[2];

        // Cache
        lineRenderer = GetComponent<LineRenderer>();
        starManager = FindObjectOfType<StarManager>();
    }

    void Update()
    {
        if (connected)
        {
            positions[0] = transform.position;
            positions[1] = FindObjectOfType<Movement>().gameObject.transform.position;
            lineRenderer.SetPositions(positions);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ConnectToPlayer();
        }
    }

    void ConnectToPlayer()
    {
        Debug.Log("working");
        connected = true;
    }
}

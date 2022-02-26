using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    StarManager starManager;
    LineRenderer lineRenderer;
    Movement player;

    public bool connected = false;
    public bool connectedToPlayer = false;

    public bool loopAtEnd;

    // Line Renderer Pos
    Vector3[] positions;
    Vector3 firstPosition;
    Vector3 secondPosition;

    void Start()
    {
        // Set Array For Line Renderer Positions
        positions = new Vector3[2];
        firstPosition = this.transform.position;
        secondPosition = this.transform.position;

        // Cache
        lineRenderer = GetComponent<LineRenderer>();
        starManager = FindObjectOfType<StarManager>();
        player = FindObjectOfType<Movement>();
    }

    void Update()
    {
        if (connected)
        {
            lineRenderer.SetPositions(positions);
        }

        if (connectedToPlayer)
        {
            secondPosition = player.transform.position;
            lineRenderer.SetPositions(positions);
        }

        positions[0] = firstPosition;
        positions[1] = secondPosition;
    }

    public void ConnectToNextStar(Vector3 firstPos, Vector3 secondPos)
    {
        connected = true;
        connectedToPlayer = false;
        lineRenderer.enabled = true;
        firstPosition = firstPos;
        secondPosition = secondPos;
    }

    public void ConnectToPlayer()
    {
        connectedToPlayer = true;
        lineRenderer.enabled = true;
    }
}

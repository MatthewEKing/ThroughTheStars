using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] Star nextStar;
    StarManager starManager;
    LineRenderer lineRenderer;

    [SerializeField] bool activated = false;
    Vector3[] positions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.enabled = false;
        positions = new Vector3[2];

        starManager = FindObjectOfType<StarManager>();
        int lengthOfStarArray = starManager.starsInLevel.Length;
        Debug.Log(lengthOfStarArray);

        for (int i = 0; i < lengthOfStarArray; i++)
        {
            if (starManager.starsInLevel[i].gameObject == this.gameObject)
            {
                nextStar = starManager.starsInLevel[i++];
            }
        }
    }

    void Update()
    {
        if (activated)
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
        activated = true;
    }
}

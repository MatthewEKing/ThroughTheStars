using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Star nextStar;
    StarManager starManager;

    [SerializeField] bool activated = false;

    void Start()
    {
        starManager = FindObjectOfType<StarManager>();
        int lengthOfStarArray = starManager.starsInLevel.Length;
        Debug.Log(lengthOfStarArray);

        for (int i = 0; i < lengthOfStarArray; i++)
        {
            if (starManager.starsInLevel[i].gameObject == this.gameObject)
            {
                Debug.Log(starManager.starsInLevel[i].gameObject.name);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activated = true;
        }
    }
}

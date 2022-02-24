using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public Star[] starsInLevel;
    public Star nextStar;

    void Start()
    {
        starsInLevel = GetComponentsInChildren<Star>();

        SetNextStar();
    }

    void SetNextStar()
    {
        for (int i = 0; i < starsInLevel.Length; i++)
        {
            if (!starsInLevel[i].connected)
            {
                nextStar = starsInLevel[i];
                return;
            }
        }
    }

    public Star GetNextStar()
    {
        return nextStar;
    }
}

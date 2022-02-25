using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public Star[] starsInLevel;
    public Star nextStar;
    public Star currentStar;
    public Star finalStar;

    void Start()
    {
        starsInLevel = GetComponentsInChildren<Star>();
        SetNextStar();
        finalStar = starsInLevel[starsInLevel.Length -1];
    }

    public void SetNextStar()
    {
        for (int i = 0; i < starsInLevel.Length; i++)
        {
            if (!starsInLevel[i].connectedToPlayer && !starsInLevel[i].connected)
            {
                nextStar = starsInLevel[i];
                return;
            }
        }
    }

    public bool CheckIfConstellationIsComplete()
    {
        for (int i = 0; i < starsInLevel.Length; i++)
        {
            if (!starsInLevel[i].connected)
            {
                return false;
            }
        }
        return true;
    }

    public void SetCurrentStar(Star star)
    {
        currentStar = star;
    }

    public Star GetNextStar()
    {
        return nextStar;
    }
}

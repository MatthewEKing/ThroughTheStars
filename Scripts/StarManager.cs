using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] Material nextStarMaterial;

    public Star[] starsInLevel;
    public Star nextStar;
    public Star currentStar;
    public Star finalStar;

    void Start()
    {
        starsInLevel = GetComponentsInChildren<Star>();
        SetNextStar();
        finalStar = starsInLevel[starsInLevel.Length - 1];
    }

    public void SetNextStar()
    {
        for (int i = 0; i < starsInLevel.Length; i++)
        {
            if (!starsInLevel[i].connectedToPlayer && !starsInLevel[i].connected)
            {
                nextStar = starsInLevel[i];
                UpdateNextStar(nextStar);
                return;
            }
        }
    }

    public void SetCurrentStar(Star currStar)
    {
        currentStar = currStar;
    }
    public Star GetNextStar()
    {
        return nextStar;
    }

    void UpdateNextStar(Star nextStar)
    {
        // change next star to signal its the next star
        nextStar.gameObject.GetComponentInChildren<MeshRenderer>().material = nextStarMaterial;
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
}

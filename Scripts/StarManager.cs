using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public Star[] starsInLevel;

    void Start()
    {
        starsInLevel = GetComponentsInChildren<Star>();
    }
}

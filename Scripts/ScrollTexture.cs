using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{

    [SerializeField] float scrollSpeed = .5f;
    [SerializeField] Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.deltaTime * scrollSpeed;
    }
}

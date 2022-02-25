using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    StarManager starManager;

    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    [SerializeField] float levelLoadDelay = 1f;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        starManager = FindObjectOfType<StarManager>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; //toggle collision
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (isTransitioning || collisionDisabled)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("Collided w/ Friendly");
                break;

            case "Finish":
                StartSucessSequence();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Star":
                HandleStarCollision(other.GetComponent<Star>());
                break;

            default:
                break;
        }
    }

    void HandleStarCollision(Star star)
    {
        Star currentStar = starManager.currentStar;
        Star nextStar = starManager.nextStar;
        Star finalStar = starManager.finalStar;

        if (star == nextStar) 
        {
            // Connects the last star with the star the player currently collided with
            if (currentStar != null)
            {
                currentStar.ConnectToNextStar(currentStar.transform.position, nextStar.transform.position);
            }

            // Restricts the final star from connecting to the player
            if (nextStar != finalStar)
            {
                nextStar.ConnectToPlayer();
            }
            else
            {
                finalStar.connected = true;
            }

            starManager.CheckIfConstellationIsComplete();
            starManager.SetCurrentStar(star);
            starManager.SetNextStar();
        }
    }

    void StartSucessSequence()
    {
        if (starManager.CheckIfConstellationIsComplete())
        {
            isTransitioning = true;
            audioSource.Stop();
            successParticles.Play();
            GetComponent<Movement>().enabled = false;
            audioSource.PlayOneShot(successSFX);
            Invoke("LoadNextLevel", levelLoadDelay);
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashSFX);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}


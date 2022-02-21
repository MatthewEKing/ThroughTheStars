using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] AudioClip thrusterSFX;
    [SerializeField] ParticleSystem thrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;

    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrusterSFX);
            }

            if (!thrusterParticles.isPlaying)
            {
                thrusterParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            thrusterParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);

            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);


            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();
        }
    }

    void ApplyRotation(float rotationDir)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDir * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

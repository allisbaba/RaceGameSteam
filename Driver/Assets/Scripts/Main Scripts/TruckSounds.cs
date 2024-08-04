using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSounds : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody truckRb;
    private AudioSource truckAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromTruck;

    void Start()
    {
        truckAudio = GetComponent<AudioSource>();
        truckRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EngineSound();
    }
    void EngineSound()
    {
        currentSpeed = truckRb.velocity.magnitude;
        pitchFromTruck = truckRb.velocity.magnitude / 50f;

        if (currentSpeed< minSpeed)
        {
            truckAudio.pitch = minPitch;
        }

        if (currentSpeed> minSpeed && currentSpeed < maxSpeed)
        {
            truckAudio.pitch = minPitch + pitchFromTruck;
        }

        if (currentSpeed > maxSpeed)
        {
            truckAudio.pitch = maxPitch;
        }
    }
}

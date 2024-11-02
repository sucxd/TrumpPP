using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSound : MonoBehaviour
{
    public AudioSource audioSource; // Assign in Inspector or GetComponent
    private Vector3 lastPosition;
    private float movementThreshold = 0.01f; // Adjust sensitivity of sound start

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        // Check if the drawer is moving
        float movement = Vector3.Distance(transform.position, lastPosition);

        if (movement > movementThreshold)
        {
            // Start the sound if the drawer is moving and sound isn't playing
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            // Stop the sound if the drawer stops moving
            if (audioSource.isPlaying)
                audioSource.Stop();
        }

        // Update the last position
        lastPosition = transform.position;
    }
}

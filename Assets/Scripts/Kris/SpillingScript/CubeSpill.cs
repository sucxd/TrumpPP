using System.Collections; // Ensure this line is included
using UnityEngine;

public class CubeSpill : MonoBehaviour
{
    public GameObject ballPrefab;         // Reference to the ball prefab
    public Transform spillOrigin;         // Reference to the new origin (empty GameObject)
    private Rigidbody rb;

    // AudioSource reference
    private AudioSource audioSource;

    // Track the spilling state
    private bool isSpilling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody attached to the cube (cup)
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same GameObject
    }

    void Update()
    {
        // Get the current tilt angle of the cube (object)
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);

        // If the object is tilted more than 90 degrees, spawn balls
        if (tiltAngle > 90f)
        {
            if (!isSpilling) // Check if we weren't spilling before
            {
                isSpilling = true; // Update spilling state
                StartSpillingAudio(); // Start playing audio normally
            }
            SpawnBall();
        }
        else
        {
            if (isSpilling) // Check if we were spilling before
            {
                isSpilling = false; // Update spilling state
                StopSpillAudio(); // Stop playing audio
            }
        }
    }

    void SpawnBall()
    {
        // Instantiate a new ball at the spillOrigin position with the same rotation as the cup
        GameObject newBall = Instantiate(ballPrefab, spillOrigin.position, spillOrigin.rotation);
        
        // Destroy the ball after 5 seconds
        Destroy(newBall, 5f);
    }

    void StartSpillingAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the spill sound from the start
            StartCoroutine(LoopSpillAudio()); // Start the coroutine to handle looping
        }
    }

    IEnumerator LoopSpillAudio()
    {
        while (isSpilling) // Loop while spilling
        {
            yield return new WaitForSeconds(audioSource.clip.length); // Wait for the audio clip to finish

            if (isSpilling) // Check if still spilling before replaying
            {
                audioSource.time = 1f; // Set to start from 1 second for the next loop
                audioSource.Play(); // Play the audio again
            }
        }
    }

    void StopSpillAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the spill sound
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class ItemInteraction : MonoBehaviour
{
    public AudioClip grabSound;    // Sound played when the item is grabbed
    public AudioClip dropSound;    // Sound played when the item is dropped
    public AudioClip dragSound;    // Sound played when the item is dragged

    private AudioSource audioSource;
    private Rigidbody rb;
    private Coroutine dragSoundCoroutine; // Coroutine for managing drag sound
    private bool isDragging; // Track if the item is being dragged

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // Set audio properties for spatial sound
        audioSource.spatialBlend = 1.0f; // 3D sound
    }

    // Called when the object is grabbed
    public void OnGrab()
    {
        PlaySound(grabSound);
        rb.isKinematic = true; // Disable physics while held
        isDragging = true; // Set dragging to true
        dragSoundCoroutine = StartCoroutine(PlayDraggingSound()); // Start dragging sound coroutine
    }

    // Called when the object is released
    public void OnRelease()
    {
        rb.isKinematic = false; // Enable physics for dropping
        isDragging = false; // Set dragging to false
        if (dragSoundCoroutine != null)
        {
            StopCoroutine(dragSoundCoroutine); // Stop dragging sound coroutine
            dragSoundCoroutine = null; // Reset coroutine reference
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only play drop sound if the object is not being held
        if (!rb.isKinematic && dropSound != null)
        {
            PlaySound(dropSound);
        }
    }

    private IEnumerator PlayDraggingSound()
    {
        while (isDragging) // Loop while the item is being dragged
        {
            PlaySound(dragSound);
            yield return new WaitForSeconds(0.5f); // Adjust the frequency of the sound as necessary
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

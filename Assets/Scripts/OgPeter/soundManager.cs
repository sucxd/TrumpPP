using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class ItemInteraction : MonoBehaviour
{
    public AudioClip grabSound;
    public AudioClip dropSound;
    public AudioClip dragSound;
    public AudioClip collisionSoundDefault;
    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isDragging;
    private XRGrabInteractable interactable;

    [System.Serializable]
    public struct CollisionSound
    {
        public string tag;
        public AudioClip sound;
    }

    public CollisionSound[] collisionSounds;
    private Dictionary<string, AudioClip> collisionSoundDict;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        collisionSoundDict = new Dictionary<string, AudioClip>();

        foreach (var collisionSound in collisionSounds)
        {
            if (!collisionSoundDict.ContainsKey(collisionSound.tag))
            {
                collisionSoundDict.Add(collisionSound.tag, collisionSound.sound);
            }
        }
    }

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnDrop);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnGrab);
            interactable.selectExited.RemoveListener(OnDrop);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        PlaySound(grabSound);
        isDragging = true;

        if (dragSound != null)
        {
            audioSource.clip = dragSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void OnDrop(SelectExitEventArgs args)
    {
        PlaySound(dropSound);
        isDragging = false;

        if (audioSource.isPlaying && audioSource.clip == dragSound)
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionSoundDict.TryGetValue(collision.gameObject.tag, out AudioClip collisionSound))
        {
            PlaySound(collisionSound);
        }
        else if (collisionSoundDefault != null)
        {
            PlaySound(collisionSoundDefault);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

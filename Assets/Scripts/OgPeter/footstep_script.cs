using System.Collections;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepSound;
    public AudioSource audioSource;
    public float stepCooldown = 0.5f; //cooldown between steps
    private bool canPlayFootstep = true;
    private Vector3 lastPosition;
    private bool playRight = true; //track it plays from right to left

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (IsMoving() && canPlayFootstep)
        {
            PlayFootstepSound();
        }
    }

    private bool IsMoving()
    {
        if (Vector3.Distance(transform.position, lastPosition) > 0.1f)
        {
            lastPosition = transform.position;
            return true;
        }

        return false;
    }

    private void PlayFootstepSound()
    {
        audioSource.clip = footstepSound;
        audioSource.panStereo = playRight ? 1f : -1f; // 1 for right, -1 for left

        audioSource.Play();
        canPlayFootstep = false; // so they dont overlap

        playRight = !playRight;

        StartCoroutine(ResetFootstepCooldown());
    }

    private IEnumerator ResetFootstepCooldown()
    {
        yield return new WaitForSeconds(stepCooldown);
        canPlayFootstep = true;
    }
}

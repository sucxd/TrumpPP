using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorLock : MonoBehaviour
{
    public XRSocketInteractor keyholeSocket; // Reference to the keyhole socket interactor
    public XRGrabInteractable handle; // Reference to the handle's interactable component
    public XRGrabInteractable key; // Reference to the key interactable component
    public Rigidbody doorRigidbody; // Reference to the door's rigidbody

    private bool isLocked = true;

    private void Start()
    {
        if (handle != null)
            handle.enabled = false; // Disable handle interaction initially

        if (keyholeSocket != null)
            keyholeSocket.selectEntered.AddListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject == key) // Check if the inserted object is the key
        {
            LockKeyInPlace();
            UnlockDoor();
        }
    }

    private void LockKeyInPlace()
    {
        if (key != null)
        {
            key.interactionLayerMask = 0; // Disable interactions on the key
            key.transform.SetParent(keyholeSocket.transform); // Set key as a child of the keyhole
            key.transform.localPosition = Vector3.zero; // Position it exactly in the keyhole
            key.transform.localRotation = Quaternion.identity; // Reset rotation
            Debug.Log("Key locked in place.");
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (handle != null)
            handle.enabled = true; // Enable handle interaction

        if (doorRigidbody != null)
            doorRigidbody.isKinematic = false; // Allow the door to move
        Debug.Log("Door unlocked!");
    }

    private void OnDestroy()
    {
        if (keyholeSocket != null)
            keyholeSocket.selectEntered.RemoveListener(OnKeyInserted);
    }
}

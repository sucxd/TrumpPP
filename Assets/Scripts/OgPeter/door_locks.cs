using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorLock : MonoBehaviour
{
    public XRSocketInteractor keyholeSocket;
    public XRGrabInteractable handle;
    public XRGrabInteractable key;
    public Rigidbody doorRigidbody;

    private bool isLocked = true;

    private void Start()
    {
        if (handle != null)
            handle.enabled = false;

        if (keyholeSocket != null)
            keyholeSocket.selectEntered.AddListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject == key)
        {
            LockKeyInPlace();
            UnlockDoor();
        }
    }

    private void LockKeyInPlace()
    {
        if (key != null)
        {
            key.interactionLayerMask = 0;
            key.transform.SetParent(keyholeSocket.transform);
            key.transform.localPosition = Vector3.zero; 
            key.transform.localRotation = Quaternion.identity; 
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

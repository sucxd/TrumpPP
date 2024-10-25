using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class door_Interactable : XRGrabInteractable
{
    [SerializeField] Transform doorTransform; // Reference to the door's transform
    [SerializeField] XRSocketInteractor keySocket;
    [SerializeField] bool isLocked;

    private Transform parentTransform;
    private const string defaultLayer = "Default";
    private const string interactableLayer = "Interactable"; // Updated from "Grab"
    private bool isGrabbed;

    [SerializeField] float doorLimitMin = 0f; // Minimum allowed door rotation in degrees
    [SerializeField] float doorLimitMax = 90f; // Maximum allowed door rotation in degrees

    private Quaternion initialRotation; // Initial door rotation

    void Start()
    {
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnDoorUnlocked);
            keySocket.selectExited.AddListener(OnDoorLocked);
        }

        parentTransform = transform.parent.transform;
        initialRotation = doorTransform.localRotation; // Store the initial door rotation
    }

    private void OnDoorLocked(SelectExitEventArgs arg0)
    {
        isLocked = true;
        Debug.Log("****DOOR LOCKED");
    }

    private void OnDoorUnlocked(SelectEnterEventArgs arg0)
    {
        isLocked = false;
        Debug.Log("****DOOR UNLOCKED");
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (!isLocked)
        {
            transform.SetParent(parentTransform);
            isGrabbed = true;
        }
        else
        {
            ChangeLayerMask(defaultLayer);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ChangeLayerMask(interactableLayer); // Changed to "Interactable"
        isGrabbed = false;
        doorTransform.localRotation = initialRotation; // Reset the door to the initial rotation if needed
    }

    void Update()
    {
        if (isGrabbed && doorTransform != null)
        {
            // Adjust door's Y-axis rotation within limits
            float currentYRotation = doorTransform.localRotation.eulerAngles.y;
            float clampedYRotation = Mathf.Clamp(currentYRotation, doorLimitMin, doorLimitMax);
            doorTransform.localRotation = Quaternion.Euler(doorTransform.localRotation.eulerAngles.x,
                                                           clampedYRotation,
                                                           doorTransform.localRotation.eulerAngles.z);
        }
    }

    private void ChangeLayerMask(string mask)
    {
        interactionLayers = InteractionLayerMask.GetMask(mask);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RealisticFlashlight : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    public Transform grabOffset; // The position offset when the flashlight is grabbed

    protected override void Awake()
    {
        base.Awake(); // Call the base class method
    }

    private void Start()
    {
        // Subscribe to the selection events with the updated signatures
        selectEntered.AddListener(OnGrab);
        selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Use interactorObject to get the transform
        Transform interactorTransform = args.interactorObject.transform;

        // Move the flashlight to a position close to the interactor
        transform.position = interactorTransform.position + grabOffset.localPosition;
        transform.rotation = interactorTransform.rotation * grabOffset.localRotation;

        // Optionally set the flashlight's parent to the interactor
        transform.SetParent(interactorTransform);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Reset the parent to the original parent
        transform.SetParent(null);
    }

    protected override void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        selectEntered.RemoveListener(OnGrab);
        selectExited.RemoveListener(OnRelease);
        base.OnDestroy();
    }
}


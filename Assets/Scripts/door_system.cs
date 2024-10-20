using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class door_Interactable : XRGrabInteractable
{
    [SerializeField] Transform doorTransform;   // Reference to the door's transform
    [SerializeField] XRSocketInteractor keySocket;
    [SerializeField] bool isLocked;

    private Transform parentTransform;
    private const string defaultLayer = "Default";
    private const string grabLayer = "Grab";
    private bool isGrabbed;
    
    [SerializeField] float doorLimitMin = 0f;    // Minimum allowed door rotation in degrees
    [SerializeField] float doorLimitMax = 90f;   // Maximum allowed door rotation in degrees
    [SerializeField] Vector3 limitDistances = new Vector3(0, 0, 90);  // Default door limit in rotation (for Z axis)
    
    private Quaternion initialRotation;  // Initial door rotation

    void Start()
    {
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnDoorUnlocked);
            keySocket.selectExited.AddListener(OnDoorLocked);
        }

        parentTransform = transform.parent.transform;
        initialRotation = doorTransform.localRotation;  // Store the initial door rotation
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
        ChangeLayerMask(grabLayer);
        isGrabbed = false;
        doorTransform.localRotation = initialRotation;  // Reset the door to the initial rotation if needed
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed && doorTransform != null)
        {
            // Monitor door's Z-axis rotation (change this to Y-axis if your door rotates differently)
            float doorZRotation = doorTransform.localRotation.eulerAngles.z;
            doorTransform.localRotation = Quaternion.Euler(doorTransform.localRotation.eulerAngles.x,
                                                           doorTransform.localRotation.eulerAngles.y,
                                                           transform.localRotation.eulerAngles.z);

            CheckLimits(doorZRotation);
        }
    }

    private void CheckLimits(float doorZRotation)
    {
        // Ensure door rotates within specified limits
        if (doorZRotation < doorLimitMin)
        {
            isGrabbed = false;
            doorTransform.localRotation = Quaternion.Euler(
                doorTransform.localRotation.eulerAngles.x,
                doorTransform.localRotation.eulerAngles.y,
                doorLimitMin
            );
            ChangeLayerMask(defaultLayer);
        }
        else if (doorZRotation > doorLimitMax)
        {
            isGrabbed = false;
            doorTransform.localRotation = Quaternion.Euler(
                doorTransform.localRotation.eulerAngles.x,
                doorTransform.localRotation.eulerAngles.y,
                doorLimitMax
            );
            ChangeLayerMask(defaultLayer);
        }
    }

    private void ChangeLayerMask(string mask)
    {
        interactionLayers = InteractionLayerMask.GetMask(mask);
    }
}

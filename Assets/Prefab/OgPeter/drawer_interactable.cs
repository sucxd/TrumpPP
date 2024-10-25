using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class drawer_Interactable : XRGrabInteractable
{
    [SerializeField] Transform drawerTrasnform;
    [SerializeField] XRSocketInteractor keySocket;
    [SerializeField] bool isLocked;

    private Transform parentTransform;
    private const string defaultLayer = "Default";
    private const string interactableLayer = "Interactable";
    private bool isGrabbed;
    private Vector3 limitPositions;
    [SerializeField] float drawerLimitZ = 0.85f;
    [SerializeField] private Vector3 limitDistances = new Vector3(.02f, .02f, 0);

    void Start()
    {
        if (keySocket != null)
        {
            keySocket.selectEntered.AddListener(OnDrawerUnlocked);
            keySocket.selectExited.AddListener(OnDrawerLocked);
        }
        parentTransform = transform.parent.transform;
        limitPositions = drawerTrasnform.localPosition;
    }

    private void OnDrawerLocked(SelectExitEventArgs arg0)
    {
        isLocked = true;
        Debug.Log("****DRAWER LOCKED");
    }

    private void OnDrawerUnlocked(SelectEnterEventArgs arg0)
    {
        isLocked = false;
        Debug.Log("****DRAWER UNLOCKED");
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
        transform.localPosition = drawerTrasnform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed && drawerTrasnform != null)
        {
            drawerTrasnform.localPosition = new Vector3(drawerTrasnform.localPosition.x,
                drawerTrasnform.localPosition.y, transform.localPosition.z);

            CheckLimits();
        }
    }

    private void CheckLimits()
    {
        if (transform.localPosition.x >= limitPositions.x + limitDistances.x ||
            transform.localPosition.x <= limitPositions.x - limitDistances.x)
        {
            ChangeLayerMask(defaultLayer);
        }
        else if (transform.localPosition.y >= limitPositions.y + limitDistances.y ||
                 transform.localPosition.y <= limitPositions.y - limitDistances.y)
        {
            ChangeLayerMask(defaultLayer);
        }
        else if (drawerTrasnform.localPosition.z <= limitPositions.z - limitDistances.z)
        {
            isGrabbed = false;
            drawerTrasnform.localPosition = limitPositions;
            ChangeLayerMask(defaultLayer);
        }
        else if (drawerTrasnform.localPosition.z >= drawerLimitZ + limitDistances.z)
        {
            isGrabbed = false;
            drawerTrasnform.localPosition = new Vector3(
                drawerTrasnform.localPosition.x,
                drawerTrasnform.localPosition.y,
                drawerLimitZ
            );
            ChangeLayerMask(defaultLayer);
        }
    }

    private void ChangeLayerMask(string mask)
    {
        interactionLayers = InteractionLayerMask.GetMask(mask);
    }
}

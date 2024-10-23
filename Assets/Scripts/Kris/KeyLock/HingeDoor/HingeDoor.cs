using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HingeDoor : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;  // Reference to the grab interactable component
    private Rigidbody rb;  // Reference to the door's Rigidbody
    private HingeJoint hinge;  // Reference to the HingeJoint component

    private void Start()
    {
        // Get the Rigidbody and HingeJoint components on the door
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();

        // Subscribe to the grab events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // When the door is grabbed, enable physics interaction
        rb.isKinematic = false;  // Allow physics to act on the door
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // When the door is released, disable physics to stop unnecessary movement
        rb.isKinematic = true;  // Freeze the door when it's not being grabbed
    }

    private void OnDestroy()
    {
        // Unsubscribe from the grab events
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}

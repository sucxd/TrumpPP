using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PushPull : MonoBehaviour
{
    public float pushPullForce = 1.0f;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;
    private Vector3 initialPosition;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Use interactorObject to get the interactor's transform
        initialPosition = args.interactorObject.transform.position;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Optionally handle release logic
    }

    void Update()
    {
        if (interactable.isSelected)
        {
            // Determine direction
            Vector3 direction = (interactable.transform.position - initialPosition).normalized;
            Vector3 movement = direction * pushPullForce * Time.deltaTime;

            // Apply movement
            interactable.transform.position += movement;
            // Consider applying the movement to Rigidbody if not Kinematic
            Rigidbody rb = interactable.GetComponent<Rigidbody>();
            if (rb != null && !rb.isKinematic)
            {
                rb.MovePosition(interactable.transform.position);
            }
        }
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }
}

using UnityEngine;

public class DrawerLimit : MonoBehaviour
{
    [SerializeField] private float minXPosition = 0.0f; // Minimum X position (closed)
    [SerializeField] private float maxXPosition = 0.3f; // Maximum X position (fully opened)

    private Vector3 initialLocalPosition;
    private bool isInteracting = false; // Track if the drawer is being interacted with

    private void Start()
    {
        // Record the drawer's initial local position
        initialLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Only update the position if interacting
        if (isInteracting)
        {
            // Get the current local position of the drawer
            Vector3 constrainedPosition = transform.localPosition;

            // Lock Y position
            constrainedPosition.y = initialLocalPosition.y;

            // Constrain only the X position while keeping Z position fixed
            constrainedPosition.x = Mathf.Clamp(constrainedPosition.x, 
                initialLocalPosition.x + minXPosition, 
                initialLocalPosition.x + maxXPosition);

            // Apply the constrained position
            transform.localPosition = constrainedPosition;
        }
    }

    // Methods to handle interaction state
    public void StartInteracting()
    {
        isInteracting = true;
    }

    public void StopInteracting()
    {
        isInteracting = false;
    }
}

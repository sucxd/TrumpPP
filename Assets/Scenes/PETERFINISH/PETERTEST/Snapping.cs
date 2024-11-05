using UnityEngine;

public class SnapToCube : MonoBehaviour
{
    public Transform snapPosition; // Position where the small cube should snap
    public float snapDistance = 0.5f; // Distance threshold for snapping

    private bool isSnapping = false; // Flag to prevent multiple snaps

    void Update()
    {
        // Check the distance between this object and the snap position
        if (!isSnapping && Vector3.Distance(transform.position, snapPosition.position) <= snapDistance)
        {
            SnapToPosition();
        }
    }

    private void SnapToPosition()
    {
        isSnapping = true; // Set flag to true to prevent further snapping
        transform.position = snapPosition.position; // Move the small cube to the snap position
        transform.rotation = snapPosition.rotation; // Optionally match the rotation
    }
}

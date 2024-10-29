using UnityEngine;

public class LockInCenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoffeeCup"))
        {
            // Snap the object to the center of this object
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation; // Optional: Match rotation if desired

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Make the object static when it snaps
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CoffeeCup"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Allow it to be picked up again
            }
        }
    }
}

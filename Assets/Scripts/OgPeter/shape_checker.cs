using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSocket : MonoBehaviour
{
    [SerializeField] private float rejectForce = 10f; // Force to push out non-shape objects

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is tagged "Shape"
        if (other.CompareTag("Shape"))
        {
            // Snap the shape to the socket position
            other.transform.position = transform.position;

            // Optionally call the sorter to check the combination
            Sorter sorter = FindObjectOfType<Sorter>();
            if (sorter != null)
            {
                sorter.CheckCombination(); // Check if the correct combination is in place
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Constantly push away objects that are not tagged as "Shape"
        if (!other.CompareTag("Shape"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calculate direction to push the object out of the socket
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;
                rb.AddForce(pushDirection * rejectForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Re-check the combination when a shape is removed
        if (other.CompareTag("Shape"))
        {
            Sorter sorter = FindObjectOfType<Sorter>();
            if (sorter != null)
            {
                sorter.CheckCombination(); // Update the combination when a shape is removed
            }
        }
    }
}

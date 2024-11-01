using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is one of the shapes
        if (other.CompareTag("Shape")) // Make sure your shapes are tagged appropriately
        {
            // Snap the shape to the socket position
            other.transform.position = transform.position; // Adjust if necessary
            other.GetComponent<Rigidbody>().isKinematic = true; // Stop it from falling

            // Optionally call the sorter to check the combination
            Sorter sorter = FindObjectOfType<Sorter>();
            if (sorter != null)
            {
                sorter.CheckCombination(); // Check if the correct combination is in place
            }
        }
    }
}

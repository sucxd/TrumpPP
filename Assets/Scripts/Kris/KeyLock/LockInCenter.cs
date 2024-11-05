using System.Collections;
using UnityEngine;

public class lockInCenter : MonoBehaviour
{
    [SerializeField] private string snapTag = "CoffeeCup";
    private GameObject snappedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(snapTag) && snappedObject == null) // Only snap if no object is currently snapped
        {
            snappedObject = other.gameObject;
            snappedObject.transform.position = transform.position;
            snappedObject.transform.rotation = transform.rotation;

            Rigidbody rb = snappedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == snappedObject)
        {
            Rigidbody rb = snappedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            snappedObject = null; // Clear the snapped reference
        }
    }

    public GameObject GetSnappedObject()
    {
        return snappedObject;
    }
}

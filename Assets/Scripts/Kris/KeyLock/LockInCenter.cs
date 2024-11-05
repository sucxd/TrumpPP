using System.Collections;
using UnityEngine;

public class LockInCenter : MonoBehaviour
{
    [SerializeField] private string snapTag = "CoffeeCup";
    [SerializeField] private float delay = 5f;
    [SerializeField] private GameObject childObjectToEnable; // Drag the CoffeeBeans child object here
    private GameObject objectInTrigger; // Current object in trigger area
    private GameObject snappedObject; // Object that has been snapped

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(snapTag))
        {
            objectInTrigger = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectInTrigger)
        {
            objectInTrigger = null;
        }
    }

    public void OnButtonPressed()
    {
        if (objectInTrigger != null && snappedObject == null) // Snap only if an object is in the trigger and nothing else is snapped
        {
            snappedObject = objectInTrigger;
            SnapObject();
        }
    }

    private void SnapObject()
    {
        // Move the object to the center and align rotation
        snappedObject.transform.position = transform.position;
        snappedObject.transform.rotation = transform.rotation;

        // Set the Rigidbody to kinematic
        Rigidbody rb = snappedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Start coroutine to enable child object and set kinematic to false after delay
        StartCoroutine(EnableChildAndReleaseKinematic());
    }

    private IEnumerator EnableChildAndReleaseKinematic()
    {
        yield return new WaitForSeconds(delay);

        if (snappedObject != null)
        {
            // Enable the specified child object (like CoffeeBeans)
            if (childObjectToEnable != null)
            {
                childObjectToEnable.SetActive(true);
            }

            // Release kinematic on the snapped object
            Rigidbody rb = snappedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }

    public GameObject GetSnappedObject()
    {
        return snappedObject;
    }
}

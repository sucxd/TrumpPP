using UnityEngine;

public class LockInCenter : MonoBehaviour
{   
    [SerializeField]
    string snapTag = "CoffeeCup"; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(snapTag))
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(snapTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }
}

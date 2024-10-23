using UnityEngine;

public class LockInCenter : MonoBehaviour
{
    public GameObject centerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == centerObject && other.CompareTag("DoorLock"))
        {
            transform.position = centerObject.transform.position;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}

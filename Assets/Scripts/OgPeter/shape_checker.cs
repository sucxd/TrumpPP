using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSocket : MonoBehaviour
{
    [SerializeField] private float rejectForce = 10f; //non "Shape" objects get pushed away
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shape"))
        {
            other.transform.position = transform.position;

            Sorter sorter = FindObjectOfType<Sorter>();
            if (sorter != null)
            {
                sorter.CheckCombination();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Shape"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;
                rb.AddForce(pushDirection * rejectForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shape"))
        {
            Sorter sorter = FindObjectOfType<Sorter>();
            if (sorter != null)
            {
                sorter.CheckCombination();
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool destroyOnTriggerEnter;
    [SerializeField] private string tagFilter;
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (IsValidTag(other))
        {
            onTriggerEnter.Invoke();
            if (destroyOnTriggerEnter)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsValidTag(other))
        {
            onTriggerExit.Invoke();
        }
    }

    // Helper method to validate the tag
    private bool IsValidTag(Collider other)
    {
        return String.IsNullOrEmpty(tagFilter) || other.CompareTag(tagFilter);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class TriggerEventHandler : MonoBehaviour
{
    // UnityEvents for trigger enter and exit
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    // Called when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Invoke the event for entering the trigger
        onTriggerEnter.Invoke();
    }

    // Called when something exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Invoke the event for exiting the trigger
        onTriggerExit.Invoke();
    }
}
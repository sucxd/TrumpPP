using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    public TaskManager taskManager;
    public bool Pickedup = false;
    private bool done;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && !done)
        {
            done = true;
            taskManager.CompleteTask(5); // Update the UI for the next task
            Destroy(gameObject); // Remove the key after pickup
            Debug.Log("Works");
        }
    }
}

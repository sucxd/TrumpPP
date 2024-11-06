using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    public TaskManager taskManager;
    public InputAction action;
    private bool Pickedup = false;
    

    private void Start()
    {
        action.AddBinding("<XRController>{LeftHand}/grip");
        action.Enable();
        action.AddBinding("<XRController>{RightHand}/grip");
        action.Enable();
    }
    void Update() {
        
    }

    // public void PickUp() 
    // {
    //     if (gameObject.CompareTag("Key") && !Pickedup)
    //     { 
    //         Pickedup = true;
    //         taskManager.CompleteTask(2);
    //         Debug.Log("Works");
    //     }
    // }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Pickedup)
        { 
            Pickedup = true;
            taskManager.CompleteTask(2);
            Debug.Log("Works");
        }
        if (other.CompareTag("Door") && Pickedup)
        {
            taskManager.CompleteTask(3); // Update the UI for the next task
            Destroy(gameObject); // Remove the key after pickup
            Debug.Log("Works");   
        }
  
    }
}

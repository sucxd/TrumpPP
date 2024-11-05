using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public TaskManager taskManager;

    public InputAction action;
    public bool Pickedup = false;

    private void Start()
    {
        action.AddBinding("<XRController>{LeftHand}/grip");
        action.Enable();
        action.AddBinding("<XRController>{RightHand}/grip");
        action.Enable();
    }

    public void PickedUp() 
    {
        if (gameObject.CompareTag("FlashLight") && !Pickedup) 
        { 
        
            Pickedup = true;
            taskManager.CompleteTask(4);
            Debug.Log("Works");
        }
    
    }

    private void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, direction, 1000) && gameObject.CompareTag("FlashLight") && action.triggered && !Pickedup)
        {
        }
    }

}

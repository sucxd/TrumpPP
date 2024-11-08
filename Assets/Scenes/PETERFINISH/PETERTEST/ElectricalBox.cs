using UnityEngine;
using UnityEngine.InputSystem;

public class ElectricalBox : MonoBehaviour
{
    public TaskManager taskManager;

    public InputAction action;
    public bool Pickedup = false;

    

    public void PickedUp() 
    {
        if (gameObject.CompareTag("Electric") && !Pickedup) 
        { 
            Pickedup = true;
            taskManager.CompleteTask(5);
            Debug.Log("Works");

        
        }
    
    }
    private void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, direction, 1000) && gameObject.CompareTag("Electric") && action.triggered && !Pickedup)
        {
        }
    }
}

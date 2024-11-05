using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class EscapeTrigger : MonoBehaviour
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

    public void PickedUp() 
    {
        if (gameObject.CompareTag("Escape") && !Pickedup)
        {
            Pickedup = true;
            taskManager.CompleteTask(5);
            Debug.Log("Works");
        }
    }
    private void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, direction, 1000) && gameObject.CompareTag("Escape") && action.triggered && !Pickedup)
        {
        }
    }


}

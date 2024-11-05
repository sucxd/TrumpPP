using UnityEngine;

public class CoffeeTrigger : MonoBehaviour
{
    
    public TaskManager task;
    private bool done = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoffeeCup") && !done)
        {
           
            done = true;
            Debug.Log("Works");
            task.CompleteTask(1); // Move to the next task 
        }
    }


}

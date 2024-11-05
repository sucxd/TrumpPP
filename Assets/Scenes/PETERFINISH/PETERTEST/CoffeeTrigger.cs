using UnityEngine;

public class CoffeeTrigger : MonoBehaviour
{
    public AudioSource plantAudio; // Assign the plant's audio in Unity
    public TaskManager task;
    private bool done = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoffeeCup") && !done)
        {
            //plantAudio.Play();
            done = true;
            Debug.Log("Works");
            task.CompleteTask(1); // Move to the next task after audio is played
        }
    }


}

using UnityEngine;
using TMPro;
using System.Linq;  // Import TextMeshPro namespace

public class TaskManager : MonoBehaviour
{
    public TMP_Text TaskUI;  // Use TMP_Text instead of Text
    private int currentTask = 0; // Tracks the current task

    [SerializeField]
    private string[] tasks = new string[]
    {
        "Make Coffee",
        "Climb and Check the Vent",
        "Find the Secret Door",
        "Explore the Room and Find Hidden Things",
        "Find the Electrical Box and Connect the Wires",
        "Escape the Brain Rot Room"
    };

    private void Start()
    {
        TaskUI.text = tasks[currentTask];
        currentTask++;
    }

    // Call this method when a task is completed and check conditions for the next task
    public void CompleteTask(int currentTask)
    {
        if (currentTask < tasks.Length)
        {
            TaskUI.text = tasks[currentTask];
        }
                // "Escape the Brain Rot Room"
        else TaskUI.text = "All tasks complete! Escape the Brain Rot Room.";
    }
}

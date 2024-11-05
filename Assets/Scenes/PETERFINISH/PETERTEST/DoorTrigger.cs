using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;

    public bool wire1 = false;
    public bool wire2 = false;
    public bool wire3 = false;
    public bool wire4 = false;

    //  to open the door
    void Update()
    {
        if (doorAnimator != null)
        {
            if (wire1 && wire2 && wire3 && wire4)
            {
                doorAnimator.SetTrigger("Open");
            }
        }
    }
}

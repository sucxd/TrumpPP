using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{

    public float deadTime = 1.0f;
    private bool deadTimeActive = false;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("I have been pressed");

        }
    }
    private void  OnTriggerExit(Collider other)
    {
        if(other.tag == "Button" && !deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("Ive been released");
            StartCoroutine(WaitForDeadTime());
        }
    }
    IEnumerator WaitForDeadTime()
    {
        deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        deadTimeActive = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap2 : MonoBehaviour
{
    [SerializeField] private GameObject box1;
    [SerializeField] private GameObject box2;
    [SerializeField] private GameObject box3;
    [SerializeField] private GameObject box4;

    [SerializeField]
    private GameObject wire;

    private Vector3 pos1;
    private Rigidbody rb;

    [SerializeField]
    private DoorController doorController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "1")
        {
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;

            pos1 = box1.transform.position;
            snappng(pos1);
        }
        if (other.gameObject.tag == "2")
        {
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;

            pos1 = box2.transform.position;
            snapping(pos1);
        }
        if (other.gameObject.tag == "3")
        {
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;

            pos1 = box3.transform.position;
            snappng(pos1);
        }
        if (other.gameObject.tag == "4")
        {
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;

            pos1 = box4.transform.position;
            snappng(pos1);
        }
    }

    private void snappng(Vector3 pos1) 
    { 
        wire.transform.position = pos1;
        doorController.wire2 = false;
    }
    
    private void snapping(Vector3 pos1)
    {
        wire.transform.position = pos1;
        doorController.wire2 = true;
    }

    public void GrabbedAgain()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.freezeRotation = false;
        rb.useGravity = true;
        doorController.wire2 = false;
    }
}

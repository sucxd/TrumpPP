using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class linecreator : MonoBehaviour
{

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;


    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
    }
}
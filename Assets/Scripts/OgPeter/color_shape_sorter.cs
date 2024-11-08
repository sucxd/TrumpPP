using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    public GameObject cylinderSocket;
    public GameObject squareSocket;
    public GameObject triangleSocket;

    public void CheckCombination()
    {
        bool cylinderCorrect = IsShapeInSocket(cylinderSocket);
        bool squareCorrect = IsShapeInSocket(squareSocket);
        bool triangleCorrect = IsShapeInSocket(triangleSocket);

        if (cylinderCorrect && squareCorrect && triangleCorrect)
        {
            // Destroy the wall if all shapes are in the correct sockets
            GameObject sorter_door_test = GameObject.Find("sorter_door_test");
            if (sorter_door_test != null)
            {
                Destroy(sorter_door_test);
            }
        }
    }

    private bool IsShapeInSocket(GameObject socket)
    {
        return socket.transform.childCount == 1; 
    }
}

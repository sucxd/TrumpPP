using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;

public class CupManager : MonoBehaviour
{
    public List<GameObject> coffeeCups; // list of coffee cups to manage
    public Button freezeButton; // UI button to freeze cups
    public GameObject newMesh; // the new mesh to change to
    public float freezeDuration = 3f; // how long to freeze the cup

    private void Start()
    {
        if (freezeButton != null)
        {
            freezeButton.onClick.AddListener(OnFreezeButtonPressed);
        }
    }

    private void OnFreezeButtonPressed()
    {
        // freeze all coffee cups
        foreach (GameObject coffeeCup in coffeeCups)
        {
            StartCoroutine(FreezeAndChangeMesh(coffeeCup));
        }
    }

    private IEnumerator FreezeAndChangeMesh(GameObject coffeeCup)
    {
        // freeze the object
        Rigidbody rb = coffeeCup.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // freeze it
        }

        yield return new WaitForSeconds(freezeDuration); // wait for a bit

        // change the mesh
        if (newMesh != null)
        {
            MeshFilter coffeeCupMeshFilter = coffeeCup.GetComponent<MeshFilter>();
            if (coffeeCupMeshFilter != null)
            {
                coffeeCupMeshFilter.mesh = newMesh.GetComponent<MeshFilter>().mesh; // change the mesh
            }
        }

        // unfreeze the object
        if (rb != null)
        {
            rb.isKinematic = false; // let it be picked up again
        }
    }
}

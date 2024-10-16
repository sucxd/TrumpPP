using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MovementSpeedChecker : MonoBehaviour
{
    public DynamicMoveProvider dynamicMoveProvider;

    void Start()
    {
        // Check if the DynamicMoveProvider is assigned, otherwise find it.
        if (dynamicMoveProvider == null)
        {
            dynamicMoveProvider = GetComponent<DynamicMoveProvider>();
        }
    }

    void Update()
    {
        // Access the current movement speed (as a float)
        float currentSpeed = dynamicMoveProvider.moveSpeed;
        Debug.Log("Current movement speed: " + currentSpeed);
    }
}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion; // Ensure this namespace is included

public class BrainRotManager : MonoBehaviour
{
    public ContinuousMoveProviderBase moveProvider; // Ensure this is assigned in the Inspector

    void Start()
    {
        // Optionally check if the moveProvider is assigned
        if (moveProvider == null)
        {
            Debug.LogError("MoveProvider is not assigned in BrainRotManager.");
        }
    }

    public void ApplyBrainRot(float amount)
    {
        // Ensure moveProvider is not null
        if (moveProvider != null)
        {
            moveProvider.moveSpeed = Mathf.Max(moveProvider.moveSpeed - amount, 0f);
            Debug.Log("Player speed reduced: " + moveProvider.moveSpeed);
        }
        else
        {
            Debug.LogError("MoveProvider is null in ApplyBrainRot.");
        }
    }
}

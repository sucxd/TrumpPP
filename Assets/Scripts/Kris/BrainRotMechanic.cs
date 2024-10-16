using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class BrainRotMechanic : MonoBehaviour
{
    public ContinuousMoveProviderBase moveProvider; // Changed from public to private, we'll assign it in code.
    public float brainRotThreshold = 5f; // Time threshold for brain rot effect
    private float timeLookingAtUI = 0f;

    void Start()
    {
 
    }

    void Update()
    {
        if (IsLookingAtUI())
        {
            timeLookingAtUI += Time.deltaTime;

            if (timeLookingAtUI >= brainRotThreshold)
            {
                ApplyBrainRotEffect();
            }
        }
        else
        {
            timeLookingAtUI = 0f;
        }
    }

    void ApplyBrainRotEffect()
    {
        if (moveProvider != null)
        {
            moveProvider.moveSpeed = Mathf.Max(moveProvider.moveSpeed - 2f, 0f);
            Debug.Log("Player speed reduced due to brain rot: " + moveProvider.moveSpeed);
        }
    }

    bool IsLookingAtUI()
    {
        // Implement your logic for UI detection here
        return true; // Placeholder: replace this with actual detection logic
    }
}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class GazeDetection : MonoBehaviour
{
    public BrainRotManager brainRotManager; // Reference to BrainRotManager
    public VignetteEffect vignetteEffect;   // Reference to VignetteEffect
    public float rayLength = 5f;            // Length of the rays
    public int numberOfRays = 3;            // Number of rays to shoot
    public float rayDensity = 10f;          // Angle density of the rays
    public string uiTag = "UI";             // Tag for UI detection
   
    public float gazeThreshold = 4f;        // Time threshold for gaze effect
    private float timeLookingAtUI = 0f;     // Track time looking at the UI

    public ContinuousMoveProviderBase continuousMoveProvider; // Reference to Dynamic Move Provider

    void Update()
    {
        CastRays();
    }

    void CastRays()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        bool isLookingAtUI = false; // Track if we are looking at a UI element

        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate the ray direction with a density offset
            Vector3 rayDirection = Quaternion.Euler(0, (i - (numberOfRays - 1) / 2f) * rayDensity, 0) * direction;

            // Draw the ray in the Scene view for debugging
            Debug.DrawRay(origin, rayDirection * rayLength, Color.green);

            // Perform the raycast
            if (Physics.Raycast(origin, rayDirection, out RaycastHit hit, rayLength))
            {
                if (hit.collider != null && hit.collider.CompareTag(uiTag))
                {
                    Debug.Log("Hit a UI element: " + hit.collider.name);
                    isLookingAtUI = true; // We are looking at a UI element
                    
                    // Increment timeLookingAtUI while looking at the UI
                    timeLookingAtUI += Time.deltaTime;

                    // Check if gaze time exceeds threshold
                    if (timeLookingAtUI >= gazeThreshold)
                    {
                        // Apply brain rot effect and decrease player speed
                        if (brainRotManager != null)
                        {
                            brainRotManager.ApplyBrainRot(0.1f); // Pass the decrease value
                        }

                        // Decrease speed in Dynamic Move Provider
                        if (continuousMoveProvider != null)
                        {
                            continuousMoveProvider.moveSpeed = Mathf.Max(continuousMoveProvider.moveSpeed - 0.1f, 0f);
                            Debug.Log("Player speed reduced due to UI detection: " + continuousMoveProvider.moveSpeed);
                        }

                        // Increase vignette effect (optional)
                        vignetteEffect.IncreaseVignette(0.1f);

                        // Reset time looking at UI after applying effects
                        timeLookingAtUI = 0f;
                    }
                }
            }
        }

        if (!isLookingAtUI)
        {
            timeLookingAtUI = 0f; // Reset time if not looking at any UI
        }
    }
}

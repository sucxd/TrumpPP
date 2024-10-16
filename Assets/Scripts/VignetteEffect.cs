using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // For URP post-processing effects

[RequireComponent(typeof(Volume))] // Ensure there's a Volume attached
public class VignetteEffect : MonoBehaviour 
{
    private Vignette vignette;

    [Range(0f, 1f)] // This will create a slider in the Inspector
    public float vignetteIntensity = 0f; // Control the intensity of the vignette effect

    void Start() 
    {
        // Get the Volume component and check if the Vignette effect is present in the profile
        Volume volume = GetComponent<Volume>();
        if (volume.profile.TryGet<Vignette>(out vignette)) // Get the Vignette settings from the volume profile
        {
            // Optionally, you can set the initial intensity here if needed
            vignette.intensity.value = vignetteIntensity;
        }
        else
        {
            Debug.LogError("Vignette effect not found in the Volume profile.");
        }
    }

    void Update() 
    {
        // Update the vignette intensity based on the slider value
        if (vignette != null)
        {
            vignette.intensity.value = vignetteIntensity; // Update vignette intensity
            Debug.Log("Vignette Intensity Updated: Current Intensity = " + vignette.intensity.value);
        }
    }

    public void IncreaseVignette(float amount) 
    {
        vignetteIntensity = Mathf.Clamp(vignetteIntensity + amount, 0f, 1f); // Increase vignette intensity, clamped between 0 and 1
        Debug.Log("Vignette Intensity Increased: Current Intensity = " + vignetteIntensity);
    }
}

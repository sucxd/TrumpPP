using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteEffect : MonoBehaviour
{
    public Volume postProcessVolume;
    private Vignette vignette;

    [Range(0f, 1f)]
    public float vignetteIntensity = 0f;

    void Start()
    {
        // Find the Vignette effect in the Post-Processing Volume
        if (postProcessVolume.profile.TryGet(out vignette))
        {
            Debug.Log("Vignette effect found in PostProcessVolume.");
        }
        else
        {
            Debug.LogWarning("No Vignette effect found in PostProcessVolume.");
        }
    }

    void Update()
    {
        if (vignette != null)
        {
            vignette.intensity.value = vignetteIntensity;
        }
    }

    public void IncreaseVignette(float amount)
    {
        if (vignette != null)
        {
            vignetteIntensity = Mathf.Clamp(vignetteIntensity + amount, 0f, 1f);
            vignette.intensity.value = vignetteIntensity;
        }
    }
}

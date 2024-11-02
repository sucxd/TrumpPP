using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class VignetteEffect : MonoBehaviour
{
    public Volume postProcessVolume;
    private Vignette vignette;

    [Range(0f, 1f)]
    public float vignetteIntensity = 0f;

    public float defaultIntensity = 1f; // Start intensity at 100%
    public float fadeDuration = 5f;     // Duration to fade out the vignette

    void Start()
    {
        if (postProcessVolume.profile.TryGet(out vignette))
        {
            vignetteIntensity = defaultIntensity;
            vignette.intensity.value = vignetteIntensity;

            // Start the fade-out coroutine
            StartCoroutine(FadeOutVignette());
        }
    }

    void Update()
    {
        if (vignette != null)
        {
            vignette.intensity.value = vignetteIntensity;
        }
    }

    private IEnumerator FadeOutVignette()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            vignetteIntensity = Mathf.Lerp(defaultIntensity, 0f, elapsed / fadeDuration);
            vignette.intensity.value = vignetteIntensity;
            elapsed += Time.deltaTime;
            yield return null;
        }

        vignetteIntensity = 0f;
        vignette.intensity.value = vignetteIntensity;
    }

    public void IncreaseVignette(float amount)
    {
        if (vignette != null)
        {
            vignetteIntensity = Mathf.Clamp(vignetteIntensity + amount, 0f, 1f);
            vignette.intensity.value = vignetteIntensity;
        }
    }

    public void SetVignetteActive(bool isActive)
    {
        if (vignette != null)
        {
            vignetteIntensity = isActive ? defaultIntensity : 0f;
            vignette.intensity.value = vignetteIntensity;
        }
    }
}

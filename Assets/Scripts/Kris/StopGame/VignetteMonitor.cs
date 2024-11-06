using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class VignetteMonitor : MonoBehaviour
{
    public Volume postProcessingVolume;
    public GameObject uiToEnable;

    private Vignette vignette;

    void Start()
    {
        StartCoroutine(StartAfterDelay());
    }

    IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        if (postProcessingVolume.profile.TryGet(out vignette))
        {
            StartCoroutine(CheckVignetteIntensity());
        }
    }

    IEnumerator CheckVignetteIntensity()
    {
        while (true)
        {
            if (vignette.intensity.value >= 1f)
            {
                StopTimeAndShowUI();
                yield break;
            }

            yield return null;
        }
    }

    void StopTimeAndShowUI()
    {
        Time.timeScale = 0f;
        uiToEnable.SetActive(true);
    }
}

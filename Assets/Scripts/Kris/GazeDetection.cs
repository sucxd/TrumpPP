using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using System.Collections;

public class GazeDetection : MonoBehaviour
{
    public BrainRotManager brainRotManager;
    public VignetteEffect vignetteEffect;
    public float rayLength = 5f;
    public int numberOfRays = 3;
    public float rayDensity = 10f;
    public string uiTag = "UI";

    public float gazeThreshold = 4f;
    private float timeLookingAtUI = 0f;

    public ContinuousMoveProviderBase continuousMoveProvider;

    public float vignetteStartDuration = 3f;

    void Start()
    {
        if (vignetteEffect != null)
        {
            StartCoroutine(StartVignetteEffect());
        }
    }

    void Update()
    {
        CastRays();
    }

    void CastRays()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        bool isLookingAtUI = false;

        for (int i = 0; i < numberOfRays; i++)
        {
            Vector3 rayDirection = Quaternion.Euler(0, (i - (numberOfRays - 1) / 2f) * rayDensity, 0) * direction;
            Debug.DrawRay(origin, rayDirection * rayLength, Color.green);

            if (Physics.Raycast(origin, rayDirection, out RaycastHit hit, rayLength))
            {
                if (hit.collider != null && hit.collider.CompareTag(uiTag))
                {
                    isLookingAtUI = true;
                    timeLookingAtUI += Time.deltaTime;

                    if (timeLookingAtUI >= gazeThreshold)
                    {
                        if (brainRotManager != null)
                        {
                            brainRotManager.ApplyBrainRot(0.2f);
                        }

                        if (continuousMoveProvider != null)
                        {
                            continuousMoveProvider.moveSpeed = Mathf.Max(continuousMoveProvider.moveSpeed - 0.1f, 0f);
                        }

                        vignetteEffect.IncreaseVignette(0.2f);
                        timeLookingAtUI = 0f;
                    }
                }
            }
        }

        if (!isLookingAtUI)
        {
            timeLookingAtUI = 0f;
        }
    }

    private IEnumerator StartVignetteEffect()
    {
        vignetteEffect.SetVignetteActive(true);
        yield return new WaitForSeconds(vignetteStartDuration);
        vignetteEffect.SetVignetteActive(false);
    }
}

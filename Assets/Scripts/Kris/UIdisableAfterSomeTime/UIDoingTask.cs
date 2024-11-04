using System.Collections;
using UnityEngine;

public class UIDoingTask : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    [SerializeField] private float displayTime = 5f;

    private void Start()
    {
        ActivateAllUIElements();
    }

    private void ActivateAllUIElements()
    {
        foreach (var uiElement in uiElements)
        {
            uiElement.SetActive(true);
            StartCoroutine(DisableAfterTime(uiElement, displayTime));
        }
    }

    public void ShowNextUIElement()
    {
        foreach (var uiElement in uiElements)
        {
            if (!uiElement.activeSelf)
            {
                uiElement.SetActive(true);
                StartCoroutine(DisableAfterTime(uiElement, displayTime));
                return;
            }
        }
    }

    private IEnumerator DisableAfterTime(GameObject uiElement, float delay)
    {
        yield return new WaitForSeconds(delay);
        uiElement.SetActive(false);
    }

    public void ResetUIElements()
    {
        foreach (var uiElement in uiElements)
            uiElement.SetActive(false);
    }
}

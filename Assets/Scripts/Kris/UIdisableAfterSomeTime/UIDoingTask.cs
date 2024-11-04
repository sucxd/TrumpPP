using System.Collections;
using UnityEngine;

public class UIDoingTask : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    [SerializeField] private float displayTime = 5f;
    [SerializeField] private float spinSpeed = 50f; // Speed of rotation on the Z-axis for each UI element

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

    private void Update()
    {
        foreach (var uiElement in uiElements)
        {
            if (uiElement.activeSelf)
            {
                uiElement.transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            }
        }
    }

    public void ResetUIElements()
    {
        foreach (var uiElement in uiElements)
            uiElement.SetActive(false);
    }
}

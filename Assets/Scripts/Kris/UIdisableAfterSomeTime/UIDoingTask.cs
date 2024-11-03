using System.Collections;
using UnityEngine;

public class UIDoingTask : MonoBehaviour
{
    public GameObject[] uiElements; // Array to hold UI elements to be activated
    public float displayTime = 5f; // Time each UI element stays active
    private int currentIndex = 0; // Index to track the current UI element to activate

    // Method to be called on button press
    public void ShowNextUIElement()
    {
        // If we've reached the end of the array, stop further activations
        if (currentIndex >= uiElements.Length)
        {
            Debug.LogWarning("All UI elements have already been shown.");
            return;
        }

        // Activate the current UI element and start the coroutine to disable it
        GameObject uiElement = uiElements[currentIndex];
        uiElement.SetActive(true);
        StartCoroutine(DisableAfterTime(uiElement, displayTime));

        // Move to the next UI element in the array
        currentIndex++;
    }

    // Coroutine to disable the UI element after the specified display time
    IEnumerator DisableAfterTime(GameObject uiElement, float delay)
    {
        yield return new WaitForSeconds(delay);
        uiElement.SetActive(false);
    }

    // Optional: Reset method to start over if needed
    public void ResetUIElements()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
        currentIndex = 0;
    }
}

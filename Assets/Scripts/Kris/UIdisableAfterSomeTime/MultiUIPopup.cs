using System.Collections;
using UnityEngine;

public class MultiUIPopup : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    [SerializeField] private float displayTime = 5f;

    private void Start()
    {
        foreach (GameObject ui in uiElements)
        {
            ui.SetActive(true);
            StartCoroutine(HideAfterTime(ui));
        }
    }

    private IEnumerator HideAfterTime(GameObject uiElement)
    {
        yield return new WaitForSeconds(displayTime);
        uiElement.SetActive(false);
    }
}

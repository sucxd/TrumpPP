using System.Collections;
using UnityEngine;

public class MultiUIPopup : MonoBehaviour
{
    public GameObject[] uiElements;
    public float displayTime = 5f;

    void Start()
    {
        StartCoroutine(HideAllAfterTime());
    }

    IEnumerator HideAllAfterTime()
    {
        yield return new WaitForSeconds(displayTime);

        foreach (GameObject ui in uiElements)
        {
            ui.SetActive(false);
        }
    }
}

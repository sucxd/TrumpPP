using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnableChildAfterDelay : MonoBehaviour
{
    [SerializeField] private LockInCenter snapToCenter;
    [SerializeField] private float delay = 5f;
    [SerializeField] private Button actionButton;

    private void Start()
    {
        actionButton.onClick.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        GameObject snappedObject = snapToCenter.GetSnappedObject();

        if (snappedObject != null)
        {
            StartCoroutine(EnableChildAfterDelayRoutine(snappedObject));
        }
    }

    private IEnumerator EnableChildAfterDelayRoutine(GameObject snappedObject)
    {
        yield return new WaitForSeconds(delay);

        // Enable the CoffeeBeans child object if it exists
        Transform coffeeBeans = snappedObject.transform.Find("CoffeeBeans");
        if (coffeeBeans != null)
        {
            coffeeBeans.gameObject.SetActive(true);
        }

        // Disable isKinematic on the snapped object's Rigidbody
        Rigidbody rb = snappedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}

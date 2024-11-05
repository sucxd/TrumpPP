using System.Collections;
using UnityEngine;

public class ForceForward : MonoBehaviour
{
    [SerializeField] private float forceAmount = 10f;
    [SerializeField] private float forceDuration = 2f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to this object!");
        }

    }

    public void ApplyForce()
    {
        if (rb != null)
        {
            StartCoroutine(ApplyForceCoroutine());
        }
    }

    private IEnumerator ApplyForceCoroutine()
    {
        float timer = 0f;
        while (timer < forceDuration)
        {
            rb.AddForce(-Vector3.right * forceAmount, ForceMode.Force);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    public void DoForceForward()
    {
        if (rb != null)
        {
            StartCoroutine(ApplyForceCoroutine());
        }
    }
}

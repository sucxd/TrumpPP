using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FridgeShake : MonoBehaviour
{
    public float shakeAmount = 0.05f;  // Fridge shake amount
    public float shakeSpeed = 5.0f;    // Shake speed
    public float tiltAmount = 5.0f;    // Shake tilt
    public float liftAmount = 0.02f;    // Lift amount when shaking
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isShaking = false;    // Shake check

    public XRController controller;   
    public InputActionReference gripAction;

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        if (gripAction.action != null && gripAction.action.IsPressed())
        {
            isShaking = true;
        }
        else
        {
            isShaking = false;
            transform.localPosition = initialPosition;
            transform.localRotation = initialRotation;
        }

        if (isShaking)
        {
            ShakeFridge();
        }
    }

    private void ShakeFridge()
    {
        float shakeOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        float tiltAngle = Mathf.Sin(Time.time * shakeSpeed) * tiltAmount;

        // Calculate lift effect: lift on one side based on shake offset
        float liftOffset = Mathf.Sin(Time.time * shakeSpeed) * liftAmount;

        // Apply side-to-side movement (Z-axis), tilt (Y-axis rotation), and lift (Y-axis position)
        // Adjust the Y position to alternate lifting sides based on shake offset
        float newYPosition = initialPosition.y + (shakeOffset > 0 ? liftOffset : -liftOffset);

        transform.localPosition = new Vector3(
            initialPosition.x, 
            newYPosition,  // Adjusted Y position for side-to-side lifting
            initialPosition.z + shakeOffset  // Apply shake offset
        );

        transform.localRotation = initialRotation * Quaternion.Euler(0, tiltAngle, 0); 
    }
}

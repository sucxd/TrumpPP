using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;
    public CapsuleCollider flashlightCollider;
    private bool isFlashlightOn = false;

    public InputAction toggleAction;

    private void OnEnable()
    {
        toggleAction.Enable();
        toggleAction.performed += ToggleFlashlight;
    }

    private void OnDisable()
    {
        toggleAction.performed -= ToggleFlashlight;
        toggleAction.Disable();
    }

    private void ToggleFlashlight(InputAction.CallbackContext context)
    {
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
        flashlightCollider.enabled = isFlashlightOn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight; //light i created
    private bool isFlashlightOn = false;
    
    public InputAction toggleAction;

    private void OnEnable()
    {
        toggleAction.Enable();
        toggleAction.performed += ToggleFlashlight; //on press?
    }

    private void OnDisable()
    {

        toggleAction.Disable();
        toggleAction.performed -= ToggleFlashlight;
    }

    private void ToggleFlashlight(InputAction.CallbackContext context)
    {
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
    }
}

using UnityEngine;

public class FlashlightTest : MonoBehaviour
{
    [SerializeField] private Light flashlight; // Reference to the Light component

    private void Start()
    {
        // Ensure the light is on at the start
        if (flashlight == null)
        {
            flashlight = GetComponent<Light>();
        }
        
        flashlight.enabled = true; // Change this to false if you want it off initially
    }

    private void Update()
    {
        // Toggle the flashlight on/off when F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}

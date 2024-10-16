using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour {
    public float playerSpeed = 2f; // Default player movement speed
    public Transform xrRig; // Reference to the XR Origin Rig
    public InputActionProperty moveAction; // Input action for movement

    void Update() {
        // Get movement input from the controller's thumbstick (Vector2)
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Convert input to movement in world space
        Vector3 moveDirection = xrRig.forward * input.y + xrRig.right * input.x;
        moveDirection.y = 0f; // Prevent the rig from moving up/down

        // Apply movement based on player speed
        xrRig.position += moveDirection * playerSpeed * Time.deltaTime;
    }

    public void ReduceSpeed(float reductionAmount) {
        playerSpeed -= reductionAmount;
        if (playerSpeed < 0) playerSpeed = 0; // Prevent negative speed

        Debug.Log("Player Speed Reduced: Current Speed = " + playerSpeed);
    }
}

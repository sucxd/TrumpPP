using UnityEngine;

public class BallCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the ball has collided with the player's head (the trigger collider)
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);  // Destroy the ball immediately
        }
    }
}

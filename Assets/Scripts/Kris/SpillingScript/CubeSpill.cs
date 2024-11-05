using UnityEngine;

public class CubeSpill : MonoBehaviour
{
    public GameObject ballPrefab;         // Reference to the ball prefab
    public Transform spillOrigin;         // Reference to the new origin (empty GameObject)
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody attached to the cube (cup)
    }

    void Update()
    {
        // Get the current tilt angle of the cube (object)
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);

        // If the object is tilted more than 90 degrees, spawn balls
        if (tiltAngle > 90f)
        {
            SpawnBall();
            
        }
    }

    void SpawnBall()
    {
        // Instantiate a new ball at the spillOrigin position with the same rotation as the cup
        GameObject newBall = Instantiate(ballPrefab, spillOrigin.position, spillOrigin.rotation);
        
        // Destroy the ball after 5 seconds
        Destroy(newBall, 5f);
    }
}

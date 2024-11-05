using UnityEngine;

public class ParticleEffectOnFloor : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 spawnPosition = collision.contacts[0].point;
            Quaternion spawnRotation = Quaternion.Euler(-90f, 0f, 0f);
            
            GameObject particleInstance = Instantiate(particlePrefab, spawnPosition, spawnRotation);
            
        }
    }
}

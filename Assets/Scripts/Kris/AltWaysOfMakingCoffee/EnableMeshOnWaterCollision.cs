using UnityEngine;

public class EnableMeshOnWaterCollision : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject cubeEnableIfCoffeeBeansInside;
    [SerializeField] private string waterBallTag = "WaterBalls";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterBallTag) && cubeEnableIfCoffeeBeansInside.activeSelf)
        {
            MeshRenderer meshRenderer = targetObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
        }
    }
}

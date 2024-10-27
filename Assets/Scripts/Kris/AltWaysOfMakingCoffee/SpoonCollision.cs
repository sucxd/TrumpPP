using UnityEngine;

public class SpoonCollision : MonoBehaviour
{
    public GameObject coffeeBeans;

    
    private void OnTriggerEnter(Collider other)
    {

        if (!coffeeBeans.activeSelf && other.CompareTag("CoffeeBeans"))
        {
            // Reduce the scale of CoffeeBeans object by 0.001 on the z-axis
            Vector3 newScale = other.transform.localScale;
            newScale.z -= 0.01f;
            other.transform.localScale = newScale;


            coffeeBeans.SetActive(true);
            Debug.Log("Is in trigger");
        }

        
    }

   
    public void DisableSpoon()
    {
        coffeeBeans.SetActive(false); 
    }
}

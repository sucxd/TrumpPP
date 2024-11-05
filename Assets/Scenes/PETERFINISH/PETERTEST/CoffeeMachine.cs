using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeCupPrefab; // Assign the coffee cup prefab in Unity
    public Transform spawnPoint;  // Assign the spawn point in Unity

    public void SpawnCoffeeCup()
    {
        
       Instantiate(coffeeCupPrefab, spawnPoint.position, spawnPoint.rotation);
       coffeeCupPrefab.tag = "CoffeeCup";
    }


}

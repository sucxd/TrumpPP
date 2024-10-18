using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollision : MonoBehaviour
{
    
    public GameObject coffeeInCup;
    public GameObject coffeBeans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(!coffeBeans.activeSelf && other.CompareTag("CoffeeCup"))
        {
            coffeBeans.SetActive(false);
            coffeeInCup.SetActive(true);
        }
    }
}

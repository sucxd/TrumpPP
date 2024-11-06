using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffeecontrol : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
 /*       GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;*/
    }
    public void StartParticles()
    {
        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

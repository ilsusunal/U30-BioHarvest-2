using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingDamage : MonoBehaviour
{
    public HealthBarS healthBarS;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("burasý çalýþýyor");
            healthBarS.AddHealth(-10); //ama bu çalýþmýyor biri prefab biri sahnedeki obje çünkü
        }
    }
}

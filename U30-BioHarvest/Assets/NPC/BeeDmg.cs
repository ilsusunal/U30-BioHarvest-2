using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDmg : MonoBehaviour
{
    public HealthBarS healthBarS;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Suya dokundu"); // Bu sat�r ile suya dokunma alg�lamas�n� kontrol edin
            healthBarS.AddHealth(-1); // Suya de�di�inde can� azalt
        }
    }
}
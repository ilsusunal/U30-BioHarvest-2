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
            Debug.Log("buras� �al���yor");
            healthBarS.AddHealth(-10); //ama bu �al��m�yor biri prefab biri sahnedeki obje ��nk�
        }
    }
}

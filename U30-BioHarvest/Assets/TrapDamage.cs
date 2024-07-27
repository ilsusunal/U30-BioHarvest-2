using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public HealthBarS healthBarS;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Suya dokundu"); // Bu satýr ile suya dokunma algýlamasýný kontrol edin
            healthBarS.AddHealth(-10); // Suya deðdiðinde caný azalt
        }
    }
}

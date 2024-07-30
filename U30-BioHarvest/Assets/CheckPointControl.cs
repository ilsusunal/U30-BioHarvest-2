using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    [SerializeField] HealthBarS healthBarS;

    private void Update()
    {
        if(healthBarS.isDead == true)
        {
            player.transform.position = vectorPoint;
            healthBarS.isDead = false;
            healthBarS.AddHealth(100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            vectorPoint = player.transform.position;
            Destroy(other.gameObject);
        }
    }
}

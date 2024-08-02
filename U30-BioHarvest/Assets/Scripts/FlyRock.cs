using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyRock : MonoBehaviour
{
    [SerializeField] GameObject childPlayer;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnFly();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            OutFly();
        }
    }
    public void OnFly()
    {
        childPlayer.transform.SetParent(this.transform);
    }

    public void OutFly()
    {
        childPlayer.transform.SetParent(null);
    }
}

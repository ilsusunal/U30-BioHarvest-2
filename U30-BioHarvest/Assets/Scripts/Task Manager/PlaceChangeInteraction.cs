using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChangeInteraction : MonoBehaviour
{
    public string placeMessage;
    public PlaceManager placeManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && placeManager != null)
        {
            placeManager.UpdatePlace(placeMessage);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && placeManager != null)
        {
            placeManager.UpdatePlace("");
        }
    }
}

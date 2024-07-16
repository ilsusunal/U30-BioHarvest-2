using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceManager : MonoBehaviour
{
    public TextMeshProUGUI placeNames;

    void Start()
    {
        if (placeNames == null)
        {
            Debug.LogError("placeNames is not assigned in the Inspector.");
        }
        else
        {
            placeNames.text = "";
        }
        //StartCoroutine(HidePlaceTextAfterDelay(3f));
    }

    /*private IEnumerator HidePlaceTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        placeNames.text = "";
    }*/

    public void UpdatePlace(string newPlace)
    {
        placeNames.text = newPlace;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            placeNames.text = "New Place Name";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeNames.text = "";
        }
    }
}

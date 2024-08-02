using UnityEngine;

public class PlantDisappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýþan nesne "Player" etiketi taþýyorsa
        if (other.CompareTag("Player"))
        {
            // Bitki nesnesini devre dýþý býrak
            gameObject.SetActive(false);
        }
    }
}

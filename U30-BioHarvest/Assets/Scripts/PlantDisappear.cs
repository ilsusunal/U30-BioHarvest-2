using UnityEngine;

public class PlantDisappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // E�er �arp��an nesne "Player" etiketi ta��yorsa
        if (other.CompareTag("Player"))
        {
            // Bitki nesnesini devre d��� b�rak
            gameObject.SetActive(false);
        }
    }
}

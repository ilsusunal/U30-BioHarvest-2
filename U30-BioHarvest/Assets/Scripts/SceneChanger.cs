using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketTrigger : MonoBehaviour
{
    public string playerTag = "Player"; // Oyuncu objesinin tag'i

    void OnTriggerEnter(Collider other)
    {
        // Eðer çarpan obje oyuncu ise
        if (other.CompareTag(playerTag))
        {
            // SpaceMissionMenu sahnesine geç
            SceneManager.LoadScene("SpaceMissionMenu");
        }
    }
}

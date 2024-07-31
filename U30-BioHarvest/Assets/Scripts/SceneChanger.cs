using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketTrigger : MonoBehaviour
{
    public string playerTag = "Player"; // Oyuncu objesinin tag'i

    void OnTriggerEnter(Collider other)
    {
        // E�er �arpan obje oyuncu ise
        if (other.CompareTag(playerTag))
        {
            // SpaceMissionMenu sahnesine ge�
            SceneManager.LoadScene("SpaceMissionMenu");
        }
    }
}

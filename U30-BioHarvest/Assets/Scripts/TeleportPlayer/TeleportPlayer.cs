using System.Collections;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float delay = 2.0f; // Iþýnlama arasýnda bekleme süresi
    public float reentryDelay = 1.0f; // Geri ýþýnlanma süresi

    private bool isTeleporting = false; // Iþýnlanma iþlemi sýrasýnda oyuncunun tekrar ýþýnlanmasýný engellemek için

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine(other.transform));
        }
    }

    private IEnumerator TeleportRoutine(Transform player)
    {
        isTeleporting = true; // Iþýnlanma iþlemini baþlat

        // B noktasýna ýþýnla
        player.position = pointB.position;
        yield return new WaitForSeconds(delay);

        // A noktasýna geri ýþýnla
        player.position = pointA.position;

        // Yeniden ýþýnlanma iþlemini belirli bir süre engelle
        yield return new WaitForSeconds(reentryDelay); // Engelleme süresi
        isTeleporting = false; // Iþýnlanma iþlemi tamamlandý, tekrar ýþýnlanmaya izin ver
    }
}

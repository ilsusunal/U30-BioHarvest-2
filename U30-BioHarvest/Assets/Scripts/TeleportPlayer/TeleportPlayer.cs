using System.Collections;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float delay = 2.0f; // I��nlama aras�nda bekleme s�resi
    public float reentryDelay = 1.0f; // Geri ���nlanma s�resi

    private bool isTeleporting = false; // I��nlanma i�lemi s�ras�nda oyuncunun tekrar ���nlanmas�n� engellemek i�in

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine(other.transform));
        }
    }

    private IEnumerator TeleportRoutine(Transform player)
    {
        isTeleporting = true; // I��nlanma i�lemini ba�lat

        // B noktas�na ���nla
        player.position = pointB.position;
        yield return new WaitForSeconds(delay);

        // A noktas�na geri ���nla
        player.position = pointA.position;

        // Yeniden ���nlanma i�lemini belirli bir s�re engelle
        yield return new WaitForSeconds(reentryDelay); // Engelleme s�resi
        isTeleporting = false; // I��nlanma i�lemi tamamland�, tekrar ���nlanmaya izin ver
    }
}

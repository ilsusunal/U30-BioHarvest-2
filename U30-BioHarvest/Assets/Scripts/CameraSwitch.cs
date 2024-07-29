using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera panelCamera;
    public Animator doorAnimator; // Kap�n�n Animator bile�enini referans olarak ekleyin
    public string openDoorTriggerName = "OpenDoor"; // Animasyon trigger�n�n ad�

    private bool hasTriggeredAnimation = false; // Animasyonun bir kez tetiklenip tetiklenmedi�ini kontrol eder

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCamera.enabled = false;
            panelCamera.enabled = true;

            // Kap� animasyonunu ba�lat
            StartDoorAnimation();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCamera.enabled = true;
            panelCamera.enabled = false;
        }
    }

    // Kap� animasyonunu ba�lat
    private void StartDoorAnimation()
    {
        if (!hasTriggeredAnimation && doorAnimator != null)
        {
            doorAnimator.SetTrigger(openDoorTriggerName);
            hasTriggeredAnimation = true; // Animasyonun sadece bir kez tetiklenmesini sa�lar
        }
    }
}

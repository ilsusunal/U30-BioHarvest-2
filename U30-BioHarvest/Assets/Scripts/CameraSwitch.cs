using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera panelCamera;
    public Animator doorAnimator; // Kapýnýn Animator bileþenini referans olarak ekleyin
    public string openDoorTriggerName = "OpenDoor"; // Animasyon triggerýnýn adý

    private bool hasTriggeredAnimation = false; // Animasyonun bir kez tetiklenip tetiklenmediðini kontrol eder

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCamera.enabled = false;
            panelCamera.enabled = true;

            // Kapý animasyonunu baþlat
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

    // Kapý animasyonunu baþlat
    private void StartDoorAnimation()
    {
        if (!hasTriggeredAnimation && doorAnimator != null)
        {
            doorAnimator.SetTrigger(openDoorTriggerName);
            hasTriggeredAnimation = true; // Animasyonun sadece bir kez tetiklenmesini saðlar
        }
    }
}

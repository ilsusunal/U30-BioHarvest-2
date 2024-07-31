using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera panelCamera;
    public Animator doorAnimator; // Kapýnýn Animator bileþenini referans olarak ekleyin
    public string openDoorTriggerName = "OpenDoor"; // Animasyon triggerýnýn adý

    private bool hasTriggeredAnimation = false; // Animasyonun bir kez tetiklenip tetiklenmediðini kontrol eder

    void Start()
    {
        // Baþlangýçta sadece playerCamera aktif olsun
        playerCamera.enabled = true;
        panelCamera.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggera girdi.");
            SwitchToPanelCamera();
            StartDoorAnimation();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggerdan çýktý.");
            SwitchToPlayerCamera();
        }
    }

    private void SwitchToPanelCamera()
    {
        playerCamera.enabled = false;
        panelCamera.enabled = true;
    }

    private void SwitchToPlayerCamera()
    {
        playerCamera.enabled = true;
        panelCamera.enabled = false;
    }

    // Kapý animasyonunu baþlat
    private void StartDoorAnimation()
    {
        if (!hasTriggeredAnimation && doorAnimator != null)
        {
            Debug.Log("Kapý animasyonu baþlatýlýyor.");
            doorAnimator.SetTrigger(openDoorTriggerName);
            hasTriggeredAnimation = true; // Animasyonun sadece bir kez tetiklenmesini saðlar
        }
    }
}

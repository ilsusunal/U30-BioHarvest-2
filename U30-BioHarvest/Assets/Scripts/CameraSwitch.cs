using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera panelCamera;
    public Animator doorAnimator; // Kap�n�n Animator bile�enini referans olarak ekleyin
    public string openDoorTriggerName = "OpenDoor"; // Animasyon trigger�n�n ad�

    private bool hasTriggeredAnimation = false; // Animasyonun bir kez tetiklenip tetiklenmedi�ini kontrol eder

    void Start()
    {
        // Ba�lang��ta sadece playerCamera aktif olsun
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
            Debug.Log("Player triggerdan ��kt�.");
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

    // Kap� animasyonunu ba�lat
    private void StartDoorAnimation()
    {
        if (!hasTriggeredAnimation && doorAnimator != null)
        {
            Debug.Log("Kap� animasyonu ba�lat�l�yor.");
            doorAnimator.SetTrigger(openDoorTriggerName);
            hasTriggeredAnimation = true; // Animasyonun sadece bir kez tetiklenmesini sa�lar
        }
    }
}

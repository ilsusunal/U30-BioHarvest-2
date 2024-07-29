using UnityEngine;
using Cinemachine;

public class Planet : MonoBehaviour
{
    public CinemachineVirtualCamera planetCamera; // Bu gezegen için atanmýþ Cinemachine sanal kamera
    private CameraSwitcher cameraSwitcher;

    private void Start()
    {
        // Kamera deðiþtirici script'ine referans al
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    private void OnMouseDown()
    {
        // Gezegen týklandýðýnda kamera geçiþini baþlat
        if (cameraSwitcher != null)
        {
            cameraSwitcher.SwitchCamera(planetCamera);
        }
    }
}

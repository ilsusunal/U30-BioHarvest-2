using UnityEngine;
using Cinemachine;

public class Planet : MonoBehaviour
{
    public CinemachineVirtualCamera planetCamera; // Bu gezegen i�in atanm�� Cinemachine sanal kamera
    private CameraSwitcher cameraSwitcher;

    private void Start()
    {
        // Kamera de�i�tirici script'ine referans al
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    private void OnMouseDown()
    {
        // Gezegen t�kland���nda kamera ge�i�ini ba�lat
        if (cameraSwitcher != null)
        {
            cameraSwitcher.SwitchCamera(planetCamera);
        }
    }
}

using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera; // Ana kamera (t�m gezegenleri g�ren kamera)
    private CinemachineVirtualCamera currentCamera;

    private void Start()
    {
        currentCamera = mainCamera;
        SetCameraPriority(mainCamera, 10); // Ana kameray� ba�lang��ta aktif yap
    }

    private void Update()
    {
        // ESC tu�una bas�ld���nda ana kameraya ge�i� yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchCamera(mainCamera);
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        if (currentCamera != null)
        {
            SetCameraPriority(currentCamera, 0); // Mevcut kameran�n �nceli�ini d���r
        }

        currentCamera = newCamera;
        SetCameraPriority(currentCamera, 10); // Yeni kameran�n �nceli�ini art�r
    }

    private void SetCameraPriority(CinemachineVirtualCamera camera, int priority)
    {
        camera.Priority = priority;
        camera.gameObject.SetActive(priority > 0);
    }
}

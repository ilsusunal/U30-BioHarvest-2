using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera; // Ana kamera (tüm gezegenleri gören kamera)
    private CinemachineVirtualCamera currentCamera;

    private void Start()
    {
        currentCamera = mainCamera;
        SetCameraPriority(mainCamera, 10); // Ana kamerayý baþlangýçta aktif yap
    }

    private void Update()
    {
        // ESC tuþuna basýldýðýnda ana kameraya geçiþ yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchCamera(mainCamera);
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        if (currentCamera != null)
        {
            SetCameraPriority(currentCamera, 0); // Mevcut kameranýn önceliðini düþür
        }

        currentCamera = newCamera;
        SetCameraPriority(currentCamera, 10); // Yeni kameranýn önceliðini artýr
    }

    private void SetCameraPriority(CinemachineVirtualCamera camera, int priority)
    {
        camera.Priority = priority;
        camera.gameObject.SetActive(priority > 0);
    }
}

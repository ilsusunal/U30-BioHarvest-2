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
        // Boþ bir alana týklanýp týklanmadýðýný kontrol et
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Interactable"))
                {
                    // Gezegen týklanmýþsa, hiçbir þey yapma
                    return;
                }
                else
                {
                    // Gezegen olmayan bir þeye týklanmýþsa, ana kameraya geçiþ yap
                    SwitchCamera(mainCamera);
                }
            }
            else
            {
                // Eðer herhangi bir gezegen veya UI'ya týklanmadýysa, ana kameraya geçiþ yap
                SwitchCamera(mainCamera);
            }
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

    private bool IsPointerOverUIObject()
    {
        // EventSystem'in sahnede olup olmadýðýný kontrol et
        if (EventSystem.current == null)
        {
            return false;
        }

        // Canvas üzerindeki UI elementlerine týklanýp týklanmadýðýný kontrol et
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

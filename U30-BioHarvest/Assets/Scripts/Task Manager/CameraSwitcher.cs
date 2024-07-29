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
        // Bo� bir alana t�klan�p t�klanmad���n� kontrol et
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Interactable"))
                {
                    // Gezegen t�klanm��sa, hi�bir �ey yapma
                    return;
                }
                else
                {
                    // Gezegen olmayan bir �eye t�klanm��sa, ana kameraya ge�i� yap
                    SwitchCamera(mainCamera);
                }
            }
            else
            {
                // E�er herhangi bir gezegen veya UI'ya t�klanmad�ysa, ana kameraya ge�i� yap
                SwitchCamera(mainCamera);
            }
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

    private bool IsPointerOverUIObject()
    {
        // EventSystem'in sahnede olup olmad���n� kontrol et
        if (EventSystem.current == null)
        {
            return false;
        }

        // Canvas �zerindeki UI elementlerine t�klan�p t�klanmad���n� kontrol et
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

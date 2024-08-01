using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    private GameObject currentPopUpPanel; // �u anda a��k olan popup paneli

    void Start()
    {
        // Ba�lang��ta t�m pop-up panellerini gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Sol fare tu�una bas�ld���nda ve t�klanan nesne "Interactable" tag'ine sahipse popup g�ster
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Interactable tag'ine sahip bir objeye t�kland�ysa
                if (hit.transform.CompareTag("Interactable"))
                {
                    ShowPopUp(hit.transform.gameObject);
                }
            }
        }

        // ESC tu�una bas�ld���nda popup'� gizle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HidePopUp();
        }
    }

    public void ShowPopUp(GameObject planet)
    {
        // �nceki a��k olan popup'� gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
        }

        // Gezegenin child canvas'�n� bul
        Transform canvasTransform = planet.transform.Find("Canvas");
        if (canvasTransform != null)
        {
            // Canvas alt�ndaki paneli bul
            Transform popUpPanelTransform = canvasTransform.Find("PopUpPanel");
            if (popUpPanelTransform != null)
            {
                currentPopUpPanel = popUpPanelTransform.gameObject;
                currentPopUpPanel.SetActive(true);
            }
        }
    }

    public void HidePopUp()
    {
        // Mevcut popup'� gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
            currentPopUpPanel = null;
        }
    }
}

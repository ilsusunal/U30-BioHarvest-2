using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    private GameObject currentPopUpPanel; // Þu anda açýk olan popup paneli

    void Start()
    {
        // Baþlangýçta tüm pop-up panellerini gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Interactable tag'ine sahip bir objeye týklandýysa
                if (hit.transform.CompareTag("Interactable"))
                {
                    ShowPopUp(hit.transform.gameObject);
                }
                else
                {
                    HidePopUp();
                }
            }
            else
            {
                HidePopUp();
            }
        }
    }

    public void ShowPopUp(GameObject planet)
    {
        // Önceki açýk olan popup'ý gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
        }

        // Gezegenin child canvas'ýný bul
        Transform canvasTransform = planet.transform.Find("Canvas");
        if (canvasTransform != null)
        {
            // Canvas altýndaki paneli bul
            Transform popUpPanelTransform = canvasTransform.Find("PopUpPanel");
            if (popUpPanelTransform != null)
            {
                currentPopUpPanel = popUpPanelTransform.gameObject;
                currentPopUpPanel.SetActive(true);
            }
            else
            {
            }
        }
        else
        {
        }
    }

    public void HidePopUp()
    {
        // Mevcut popup'ý gizle
        if (currentPopUpPanel != null)
        {
            currentPopUpPanel.SetActive(false);
            currentPopUpPanel = null;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPanel;

    void Start()
    {
        popUpPanel.SetActive(false); // Baþlangýçta pop-up panelini gizle
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    ShowPopUp();
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

    public void ShowPopUp()
    {
        popUpPanel.SetActive(true);
    }

    public void HidePopUp()
    {
        popUpPanel.SetActive(false);
    }
}

using UnityEngine;

public class WorldInteraction : MonoBehaviour
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
                if (hit.transform == transform)
                {
                    ShowPopUp();
                }
                else if (popUpPanel.activeSelf)
                {
                    HidePopUp();
                }
            }
            else if (popUpPanel.activeSelf)
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

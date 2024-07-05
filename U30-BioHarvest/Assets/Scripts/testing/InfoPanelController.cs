using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;

    void Awake()
    {
        Debug.Log("InfoPanelController attached to: " + gameObject.name); 
    }

    public void ShowPanel()
    {
        Debug.Log("Showing panel: " + infoPanel.name); 
        infoPanel.SetActive(true); 
    }

    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }

    public void StartLevel(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

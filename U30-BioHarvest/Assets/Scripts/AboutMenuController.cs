using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject teamPanel;
    public GameObject gamePanel;

    //Team bolumu paneli - TEAM butonu icin
    public void OpenTeam()
    {
        teamPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    //Game bolumu paneli - BIOHARVEST butonu icin
    public void OpenBioHarvest()
    {
        gamePanel.SetActive(true);
        teamPanel.SetActive(false);
    }

    //Ayarlar bolumu paneli - SETTINGS butonu icin
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        gamePanel.SetActive(false);
        teamPanel.SetActive(false);
    }

    //Start menüye dönme  - EXIT butonu icin
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}

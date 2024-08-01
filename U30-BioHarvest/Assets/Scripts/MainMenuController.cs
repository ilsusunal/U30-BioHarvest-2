using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject exitConfirmationPanel;

    //Bolum secme sahnesi - START butonu icin
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("SpaceMissionMenu");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }

    //Takim ve oyun hakkinda sahnesi - ABOUT butonu icin
    public void LoadAboutTeam()
    {
        SceneManager.LoadScene("AboutTeamSecene");
    }

    //Ayarlar bolumu paneli - SETTINGS butonu icin
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    //Oyundan cikma onayi paneli - EXIT butonu icin
    public void OpenExitConfirmation()
    {
        exitConfirmationPanel.SetActive(true);
    }

    public void CloseExitConfirmation()
    {
        exitConfirmationPanel.SetActive(false);
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }
}

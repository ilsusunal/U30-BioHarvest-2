using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPanelManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject audioSettingsPanel;
    public GameObject controlSettingsPanel;
    public GameObject graphicsPanel;

    public Button audioButton;
    public Button controlButton;
    public Button graphicsButton;
    public Button exitButton;
    public Button stayButton;

    private bool isCursorVisible = false;

    private void Start()
    {
        settingsPanel.SetActive(false);

        ShowAudioSettings();


        audioButton.onClick.AddListener(ShowAudioSettings);
        controlButton.onClick.AddListener(ShowControlSettings);
        graphicsButton.onClick.AddListener(ShowGraphicsPanel);
        exitButton.onClick.AddListener(ExitToLevelSelection);
        stayButton.onClick.AddListener(HideSettingsPanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                HideSettingsPanel();
            }
            else
            {
                ShowSettingsPanel();
                Debug.Log("Cursor is visible : " + isCursorVisible);
            }
        }
    }

    private void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        SetCursorVisibility(true);
    }

    private void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        SetCursorVisibility(false);
    }

    private void ShowAudioSettings()
    {
        audioSettingsPanel.SetActive(true);
        controlSettingsPanel.SetActive(false);
        graphicsPanel.SetActive(false);
    }

    private void ShowControlSettings()
    {
        audioSettingsPanel.SetActive(false);
        controlSettingsPanel.SetActive(true);
        graphicsPanel.SetActive(false);
    }

    private void ShowGraphicsPanel()
    {
        audioSettingsPanel.SetActive(false);
        controlSettingsPanel.SetActive(false);
        graphicsPanel.SetActive(true);
    }

    private void ExitToLevelSelection()
    {
        SceneManager.LoadScene("Start Menu");
    }

    private void SetCursorVisibility(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

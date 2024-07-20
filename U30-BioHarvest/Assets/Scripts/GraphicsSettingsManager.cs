using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsController : MonoBehaviour
{
    [SerializeField] private Button resolution1080pButton;
    [SerializeField] private Button resolution720pButton;

    [SerializeField] private Button fullScreenButton;
    [SerializeField] private Button windowedButton;

    [SerializeField] private Button qualityLowButton;
    [SerializeField] private Button qualityMediumButton;
    [SerializeField] private Button qualityHighButton;
    [SerializeField] private Button qualityUltraButton;

    private void Start()
    {
        resolution1080pButton.onClick.AddListener(() => SetResolution(1920, 1080));
        resolution720pButton.onClick.AddListener(() => SetResolution(1280, 720));

        fullScreenButton.onClick.AddListener(() => SetDisplayMode(FullScreenMode.FullScreenWindow));
        windowedButton.onClick.AddListener(() => SetDisplayMode(FullScreenMode.Windowed));

        qualityLowButton.onClick.AddListener(() => SetQuality(0));
        qualityMediumButton.onClick.AddListener(() => SetQuality(2));
        qualityHighButton.onClick.AddListener(() => SetQuality(3));
        qualityUltraButton.onClick.AddListener(() => SetQuality(5));
    }

    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    private void SetDisplayMode(FullScreenMode mode)
    {
        Screen.fullScreenMode = mode;
    }

    private void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}

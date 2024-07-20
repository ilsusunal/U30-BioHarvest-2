using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensitivityManager : MonoBehaviour
{
    [SerializeField] AstraCameraController cameraController;
    [SerializeField] Slider sensitivitySlider;

    private void Start()
    {
        if (cameraController != null && sensitivitySlider != null)
        {
            sensitivitySlider.value = cameraController.rotationSpeed;
            sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
        }
        else
        {
            Debug.LogWarning("CameraController veya Slider referansý atanmadý.");
        }
    }

    private void SetSensitivity(float value)
    {
        cameraController.rotationSpeed = value;
    }
}

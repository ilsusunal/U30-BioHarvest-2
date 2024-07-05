using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClickHandler : MonoBehaviour
{
    public CameraController cameraController;

    void OnMouseDown()
    {
        Debug.Log("Planet clicked: " + gameObject.name);
        cameraController.ZoomToPlanet(transform);
    }
}

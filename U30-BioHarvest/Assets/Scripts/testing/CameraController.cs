using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] planets;
    public float zoomSpeed = 2.0f;
    public Vector3 offset; 

    private Transform targetPlanet;
    private bool isZooming = false;

    void Update()
    {
        if (isZooming)
        {
            Vector3 targetPosition = targetPlanet.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isZooming = false; 
                ShowInfoPanel(); //TODO : Burasý çalýþmýyor!
            }
        }
    }

    public void ZoomToPlanet(Transform planet)
    {
        Debug.Log("Zooming to planet: " + planet.name);
        targetPlanet = planet; 
        isZooming = true;
    }

    void ShowInfoPanel()
    {
        Debug.Log("Trying to show info panel on planet: " + targetPlanet.name);
        DebugHierarchy.PrintHierarchy(targetPlanet);
        Debug.Log("Getting InfoPanelController component...");
        InfoPanelController infoPanel = targetPlanet.GetComponentInChildren<InfoPanelController>();
        Debug.Log("InfoPanelController found: " + (infoPanel != null)); //Buradan false dönüyor!!!
        if (infoPanel != null)
        {
            Debug.Log("InfoPanelController found!");
            infoPanel.ShowPanel();
        }
        else
        {
            Debug.LogWarning("No InfoPanelController found on target planet.");
        }
    }
}

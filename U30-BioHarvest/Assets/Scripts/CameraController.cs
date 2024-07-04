using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] planets; // Array of planet transforms
    public float zoomSpeed = 2.0f; // Speed at which the camera will zoom in
    public Vector3 offset; // Offset to position the camera correctly

    private Transform targetPlanet; // The planet the camera will zoom into
    private bool isZooming = false; // Flag to check if the camera is currently zooming

    void Update()
    {
        if (isZooming)
        {
            // Calculate the target position for the camera
            Vector3 targetPosition = targetPlanet.position + offset;
            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);

            // Check if the camera is close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isZooming = false; // Stop zooming
                ShowInfoPanel(); // Display the info panel
            }
        }
    }

    public void ZoomToPlanet(Transform planet)
    {
        Debug.Log("Zooming to planet: " + planet.name); // Debug statement
        targetPlanet = planet; // Set the target planet
        isZooming = true; // Start zooming
    }

    void ShowInfoPanel()
    {
        Debug.Log("Trying to show info panel on planet: " + targetPlanet.name); // Debug statement
        // Print the hierarchy for debugging
        DebugHierarchy.PrintHierarchy(targetPlanet);
        // Debug before getting component
        Debug.Log("Getting InfoPanelController component...");
        // Find the InfoPanelController on the target planet's children
        InfoPanelController infoPanel = targetPlanet.GetComponentInChildren<InfoPanelController>();
        // Debug after getting component
        Debug.Log("InfoPanelController found: " + (infoPanel != null));
        if (infoPanel != null)
        {
            Debug.Log("InfoPanelController found!"); // Debug statement
            infoPanel.ShowPanel(); // Show the info panel
        }
        else
        {
            Debug.LogWarning("No InfoPanelController found on target planet.");
        }
    }
}

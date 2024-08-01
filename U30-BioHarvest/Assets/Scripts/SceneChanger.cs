using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string playerTag = "Player"; // Oyuncu objesinin tag'i
    public GameObject panel;
    public GameObject canvasF;

    private void Start()
    {
        panel.SetActive(false);
        canvasF.SetActive(true);
    }
    public void OpenCanvas()
    {
        canvasF.SetActive(false);
        panel.SetActive(true);
    }

    

    private void Update()
    {
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("sahne deðiþtir");
            SceneManager.LoadScene("SpaceMissionMenu");
        }
    }
}

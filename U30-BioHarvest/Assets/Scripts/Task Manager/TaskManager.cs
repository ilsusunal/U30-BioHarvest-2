using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

interface IInteractable{
    public void Interact();
}
public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    [SerializeField] private float interactRange; 
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject buttonCanvas;
    [SerializeField] private GameObject interactionCamera;

    [SerializeField] private GameObject miniTaskPanel;
    [SerializeField] private TMP_Text toggleButtonText;

    public TextMeshProUGUI miniTaskText1;
    public TextMeshProUGUI miniTaskText2;
    public TextMeshProUGUI miniTaskText3;
    public Image miniTaskBackground1;
    public Image miniTaskBackground2;
    public Image miniTaskBackground3;
    public string task1Content;
    public string task2Content;
    public string task3Content;


    void Start()
    {
        taskText.text = "Hello Astra! Are you ready for a new adventure?";
        buttonCanvas.SetActive(false);

        miniTaskPanel.SetActive(false);
        toggleButtonText.text = "+";

        miniTaskText1.text = task1Content;
        miniTaskText2.text = task2Content;
        miniTaskText3.text = task3Content;
        miniTaskBackground1.color = Color.white;
        miniTaskBackground2.color = Color.white;
        miniTaskBackground3.color = Color.white;
    }

    //Task güncellemesi
    public void UpdateTask(string newTask)
    {
        taskText.text = newTask;
    }

    //"Press M" yazýsýnýn çýkmasý
    public void UpdateButtonCanvas(GameObject newButtonCanvas)
    {
        buttonCanvas = newButtonCanvas;
    }

    //Ek görevler panelinin açýlmasý
    public void ControlMiniTaskPanel()
    {
        miniTaskPanel.SetActive(!miniTaskPanel.activeSelf);
        toggleButtonText.text = miniTaskPanel.activeSelf ? "-" : "+";
    }
    public void CompleteTask(TextMeshProUGUI taskText, Image taskBackground)
    {
        taskText.color = Color.gray;
        taskBackground.color = Color.green;
        taskText.fontStyle = FontStyles.Strikethrough;
    }

    void Update()
    {
        Ray ray = new Ray(interactionCamera.transform.position, interactionCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange, interactableLayer))
        {
            //Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
            //Debug.Log("ButtonCanvas active? " + buttonCanvas.activeSelf);


            if (!buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(true);
            }

            if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                //Debug.Log("Object does not implement IInteractable.");
            }
        }
        else
        {
            if (buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ControlMiniTaskPanel();
        }
    }
}

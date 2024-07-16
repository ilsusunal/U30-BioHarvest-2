using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable{
    public void Interact();
}
public class JungleTaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    [SerializeField] private float interactRange; 
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject buttonCanvas;
    [SerializeField] private Camera interactionCamera;
    private bool isPlayerInRange = false;


    void Start()
    {
        taskText.text = "Hello Astra! Are you ready for a new adventure?";
    }

    public void UpdateTask(string newTask)
    {
        taskText.text = newTask;
    }

    void Update()
    {
        Ray ray = new Ray(interactionCamera.transform.position, interactionCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange, interactableLayer))
        {
            isPlayerInRange = true;
            Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
            Debug.Log("ButtonCanvas active? " + buttonCanvas.activeSelf);


            if (!buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(true);
            }

            if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if (Input.GetKeyDown(KeyCode.M))
                {
                    interactable.Interact();
                }
            }
            else
            {
                Debug.Log("Object does not implement IInteractable.");
            }
        }
        else
        {
            isPlayerInRange = false;
            if (buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(false);
            }
        }
    }
}

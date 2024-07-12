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
    public TextMeshProUGUI placeNames;


    void Start()
    {
        taskText.text = "Hello Astra! Are you ready for a new adventure?";
        if (placeNames == null)
        {
            Debug.LogError("placeText is not assigned in the Inspector.");
        }
        else
        {
            placeNames.text = "Haven of Seeds";
        }
    }

    public void UpdateTask(string newTask)
    {
        taskText.text = newTask;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.collider.gameObject.name); 

                if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Interact();
                }
                else
                {
                    Debug.Log("Object does not implement IInteractable.");
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any objects.");
            }
        }

    }
    /* 
          if (Input.GetKeyDown(KeyCode.M))
        {
            float interactRange = 10f;
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                Debug.Log("Hit: " + hitInfo.collider.gameObject.name);
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj)){
                    
                    interactableObj.Interact();
                }
    
            }
        }
     
     */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChangeInteraction : MonoBehaviour, IInteractable
{
    public string taskMessage;
    public TaskManager taskManager;
    public GameObject buttonCanvas;

    public void ChangeButtonCanvas()
    {
        if (taskManager != null)
        {
            taskManager.UpdateButtonCanvas(buttonCanvas);
        }
    }
    public void Interact()
    {
        if (taskManager != null)
        {
            taskManager.UpdateTask(taskMessage);
            
        }
    }
}

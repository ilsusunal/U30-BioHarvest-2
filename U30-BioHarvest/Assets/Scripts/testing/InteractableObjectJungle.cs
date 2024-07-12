using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectJungle : MonoBehaviour, IInteractable
{
    public string taskMessage;
    public JungleTaskManager taskManager;
    public void Interact()
    {
        if (taskManager != null)
        {
            taskManager.UpdateTask(taskMessage);
        }
    }
}

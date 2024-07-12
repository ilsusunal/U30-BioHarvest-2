using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChangeInteraction : MonoBehaviour
{
    public string placeMessage;
    public JungleTaskManager taskManager;
    public void Interact()
    {
        if (taskManager != null)
        {
            taskManager.UpdatePlace(placeMessage);
        }
    }
}

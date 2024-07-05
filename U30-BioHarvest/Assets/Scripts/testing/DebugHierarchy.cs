using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHierarchy : MonoBehaviour
{
    public static void PrintHierarchy(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Debug.Log(child.name + " - " + child.gameObject.GetComponent<InfoPanelController>());
            PrintHierarchy(child);
        }
    }
}

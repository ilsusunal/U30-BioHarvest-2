using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    public GameObject miniMap;
    private bool isMiniMapActive = false;

    void Start()
    {
        if(miniMap == null)
        {
            Debug.LogError("MiniMap GameObject is not assigned in the Inspector.");
        }
        else
        {
            miniMap.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMiniMapActive = !isMiniMapActive;
            miniMap.SetActive(isMiniMapActive);
        }
    }
    
}

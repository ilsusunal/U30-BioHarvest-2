using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    void Update()
    {
        
    }
}

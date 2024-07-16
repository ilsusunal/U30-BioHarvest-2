using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager2 : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI placeNames;
    [SerializeField] private GameObject buttonCanvas;

    private void Start()
    {
        taskText.text = "Hello Astra! Are you ready for a new adventure?";
        placeNames.text = "Haven of Seeds";
        StartCoroutine(HidePlaceTextAfterDelay(3f));
    }

    private IEnumerator HidePlaceTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        placeNames.text = "";
    }

    public void UpdateTask(string newTask)
    {
        taskText.text = newTask;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            placeNames.text = "New Place Name";
            if (!buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeNames.text = "";
            if (buttonCanvas.activeSelf)
            {
                buttonCanvas.SetActive(false);
            }
        }
    }
}

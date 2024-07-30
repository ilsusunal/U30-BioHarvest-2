using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaShellsControl : MonoBehaviour
{
    bool isSeePlayer;
    [SerializeField] private GameObject[] SeaShells;
    private int currentIndex = 0;
    private int pressCount = 0;
    public bool completedShellsMis;
    [SerializeField] Animator Pinkanimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (isSeePlayer))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.SeaShell)
            {
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                pressCount++;
                GameObject gameObject = SeaShells[currentIndex];
                gameObject.SetActive(true);
                currentIndex = (currentIndex + 1) % SeaShells.Length;
            }
        }
        if (pressCount == 10)
        {
            completedShellsMis = true;
            Pinkanimator.SetTrigger("Completed");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSeePlayer = true;
        }
    }
}

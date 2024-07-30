using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    bool isSeePlayer;
    [SerializeField] Animator Redanimator;
    int pressCount;

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.F) && (isSeePlayer))
            {
                if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Slime)
                {
                    InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                    pressCount++;
                }
            }
            if(pressCount >= 5)
            {
            Redanimator.SetTrigger("Completed");
            }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSeePlayer = true;
            //Debug.Log("görüyom");
        }
    }
}

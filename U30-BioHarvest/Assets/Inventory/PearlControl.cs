using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlControl : MonoBehaviour
{
    [SerializeField] GameObject pearlOnStand;
    bool isSeePlayer;
    [SerializeField] Animator Blackanimator;
    private void Awake()
    {
        pearlOnStand.SetActive(false);
    }
    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.F) && (isSeePlayer))
            {
                if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Pearl) 
                {
                    InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                    pearlOnStand.SetActive(true);
                    Blackanimator.SetTrigger("Completed");
                }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlControl : MonoBehaviour
{
    [SerializeField] GameObject pearlOnStand;
    bool isSeePlayer;

    private void Awake()
    {
        pearlOnStand.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (isSeePlayer))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Pearl) //buraya standý görmeyi kontrol et
            {
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                pearlOnStand.SetActive(true);
            }
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

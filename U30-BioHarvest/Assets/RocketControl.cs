using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    //rokete yerleþtirilecek objeler içindir

    [SerializeField] GameObject sitAstra;
    [SerializeField] GameObject Seed;
    [SerializeField] GameObject LifeCrystal;
    [SerializeField] GameObject QBee;

    public SceneChanger sceneChanger;

    private void Awake()
    {
        Seed.SetActive(false);
        LifeCrystal.SetActive(false);
        QBee.SetActive(false);
    }
    private void Update()
    {
        if (sitAstra.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Seed)
            {
                Debug.Log("Seed Found" + Seed.name);
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                Seed.SetActive(true);
                sceneChanger.OpenCanvas();
            }
        }
        if (sitAstra.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.LifeCrytal)
            {
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                LifeCrystal.SetActive(true);
                sceneChanger.OpenCanvas();
            }
        }
        if (sitAstra.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Queen)
            {
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                QBee.SetActive(true);
                sceneChanger.OpenCanvas();
            }
        }
        if (sitAstra.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.itemToUse.itemName == ItemSO.ItemNames.Plant007)
            {
                InventoryManager.Instance.UseItem(InventoryManager.Instance.itemToUse);
                sceneChanger.OpenCanvas();
            }
        }
    }
}
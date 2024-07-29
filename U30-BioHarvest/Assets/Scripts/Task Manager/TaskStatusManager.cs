using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskStatusManager : MonoBehaviour
{
    public static TaskStatusManager Instance;
    public TaskManager taskManager;
    private InventoryManager inventoryManager;

    public int itemsCollected = 0;
    public int itemsToCollect = 1;
    public bool noDamageTaken = true;
    public int enemiesDefeated = 0;
    public int enemiesToDefeat = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
        UpdateTaskStatuses();
    }

    public void CollectItemForTask(int itemNo) //Inventory managera şunun eklenmasi lazım:  TaskStatusManager.Instance.CollectItem();
    {
        itemsCollected += itemNo;
        Debug.Log(" Collected item no : " + itemsCollected);
        if (itemsCollected == itemsToCollect)
        {
            UpdateTaskStatuses();
            Debug.Log(" MINI TASK 1 COMPLETED ");
        }
    }

    public void TakeDamage() //Healthe şunun eklenmesi lazım: TaskStatusManager.Instance.TakeDamage();
    {
        noDamageTaken = false;
        UpdateTaskStatuses();
    }

    public void DefeatEnemy() //Enemy için şunun eklenmesi lazım: TaskStatusManager.Instance.DefeatEnemy();
    {
        enemiesDefeated++;
        if (enemiesDefeated >= enemiesToDefeat)
        {
            taskManager.CompleteTask(taskManager.miniTaskText3, taskManager.miniTaskBackground3);
        }
        UpdateTaskStatuses();
    }

    private void UpdateTaskStatuses()
    {
        if (itemsCollected >= itemsToCollect)
        {
            taskManager.CompleteTask(taskManager.miniTaskText1, taskManager.miniTaskBackground1);
        }

        if (!noDamageTaken)
        {
            taskManager.miniTaskText2.text = "Task Failed: Took Damage";
            taskManager.miniTaskBackground2.color = Color.red;
        }

        if (enemiesDefeated >= enemiesToDefeat)
        {
            taskManager.CompleteTask(taskManager.miniTaskText3, taskManager.miniTaskBackground3);
        }
    }
}

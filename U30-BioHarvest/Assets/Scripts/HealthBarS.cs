using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarS : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] int maxHealth;
    int health;
    public bool isDead;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddHealth(-20);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddHealth(10);
        }
        if(health != maxHealth)
        {
            TaskStatusManager.Instance.TakeDamageForTask();
            Debug.Log("DAMAGE TAKEN MISSION FAIL");
        }
    }

    public void AddHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
            isDead = true;
        }

        healthBar.value = health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarS : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] int maxHealth;
    int health;

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
    }

    void AddHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        healthBar.value = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("Suya dokundu"); // Bu satýr ile suya dokunma algýlamasýný kontrol edin
            AddHealth(-10); // Suya deðdiðinde caný azalt
        }
    }
}

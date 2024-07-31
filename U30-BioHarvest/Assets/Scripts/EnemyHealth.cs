using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health : " + health);
        if (health <= 0)
        {
            TaskStatusManager.Instance.DefeatEnemy();
            Destroy(gameObject);
        }
    }
}
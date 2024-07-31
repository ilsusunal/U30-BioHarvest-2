using UnityEngine;

public class SidekickAI : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2.0f;
    public float height = 1.0f;
    public float smoothSpeed = 0.125f;
    public float detectionRadius = 10.0f;
    public LayerMask enemyLayer;
    public GameObject axePrefab;
    public Transform firePoint;
    public float axeSpeed = 20.0f;

    private Transform targetEnemy;

    void LateUpdate()
    {
        if (targetEnemy != null)
        {
            AttackEnemy();
        }
        else
        {
            FollowPlayer();
            DetectEnemies();
        }
    }

    void FollowPlayer()
    {
        Vector3 desiredPosition = player.position + player.forward * followDistance + Vector3.up * height;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }

    void DetectEnemies()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        if (enemiesInRange.Length > 0)
        {
            targetEnemy = enemiesInRange[0].transform;
        }
    }

    void AttackEnemy()
    {
        GameObject axe = Instantiate(axePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = axe.GetComponent<Rigidbody>();
        rb.velocity = (targetEnemy.position - firePoint.position).normalized * axeSpeed;
    }
}

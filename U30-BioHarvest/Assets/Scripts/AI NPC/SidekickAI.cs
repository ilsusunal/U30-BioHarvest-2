using UnityEngine;

public class SidekickAI : MonoBehaviour
{
    public Transform mainCharacter;
    public float hoverHeight = 2f;
    public float hoverRadius = 2f;
    public float followDistance = 3f;
    public float minFollowDistance = 1f; // Minimum takip mesafesi
    public float attackRange = 5f;
    public float detectionRange = 10f;
    public string enemyTag = "Enemy";
    public LayerMask enemyLayer;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float followSpeed = 5f;

    public Vector3 offsetPosition = new Vector3(2f, 2f, 2f); // Yanc�n�n konumu i�in offset

    private Transform currentTarget;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectAndAttackEnemies();
        FollowAndHover();
    }

    void DetectAndAttackEnemies()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRange, enemyLayer);
        if (enemies.Length > 0)
        {
            currentTarget = GetClosestEnemy(enemies);
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

            if (distanceToTarget <= attackRange)
            {
                if (distanceToTarget > minFollowDistance && Input.GetMouseButtonDown(0))
                {
                    AttackTarget();
                }
                else if (distanceToTarget <= minFollowDistance)
                {
                    // D��mana �ok yakla�t�ysa, geri �ekil
                    MoveAwayFrom(currentTarget.position);
                }
                else
                {
                    MoveTowards(currentTarget.position);
                    animator.SetBool("isAttacking", false);
                }
            }
        }
        else
        {
            currentTarget = null;
        }
    }

    Transform GetClosestEnemy(Collider[] enemies)
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }

    void AttackTarget()
    {
        if (currentTarget != null)
        {
            animator.SetBool("isAttacking", true);
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    void FollowAndHover()
    {
        if (currentTarget == null)
        {
            Vector3 hoverPosition = mainCharacter.position + offsetPosition;
            hoverPosition.y = mainCharacter.position.y + hoverHeight; // Yanc�n�n havada kalmas�n� sa�lamak i�in y�ksekli�i sabitleyin
            float distanceToCharacter = Vector3.Distance(transform.position, mainCharacter.position);

            if (distanceToCharacter > followDistance)
            {
                MoveTowards(mainCharacter.position + offsetPosition);
                animator.SetBool("isFollowing", true);
            }
            else if (distanceToCharacter < minFollowDistance)
            {
                // Yanc� �ok yak�nsa, geriye do�ru hareket ettirin
                MoveTowards(mainCharacter.position + offsetPosition - (mainCharacter.position - transform.position).normalized * minFollowDistance);
                animator.SetBool("isFollowing", true);
            }
            else
            {
                MoveTowards(hoverPosition);
                animator.SetBool("isFollowing", false);
            }
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;
    }

    void MoveAwayFrom(Vector3 targetPosition)
    {
        Vector3 direction = (transform.position - targetPosition).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

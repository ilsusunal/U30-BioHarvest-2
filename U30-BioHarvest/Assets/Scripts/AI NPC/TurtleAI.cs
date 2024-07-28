using UnityEngine;
using UnityEngine.AI;

public class TurtleAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 100f;
    public float attackRange = 60f;
    public int damage = 10;
    public float attackCooldown = 2f;

    [SerializeField] private Transform[] patrolPoints;  // Devriye noktalarýný temsil eder
    private NavMeshAgent agent;
    private Animator animator;
    private float lastAttackTime;
    private int currentPatrolIndex;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator bileþeni bulunamadý! Lütfen TurtleShellPBR GameObject'ine bir Animator bileþeni ekleyin.");
        }

        lastAttackTime = -attackCooldown;  // Ýlk saldýrýnýn hemen gerçekleþebilmesi için

        // Ýlk devriye noktasýna git
        if (patrolPoints.Length > 0)
        {
            currentPatrolIndex = 0;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
            }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // Bir sonraki devriye noktasýna geç
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }

        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //Debug.Log("PLAYER FOUND!!!");
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void AttackPlayer()
    {
        //Debug.Log("ATTACK!!!");
        lastAttackTime = Time.time;
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
            animator.SetTrigger("attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                DealDamageToPlayer(other.gameObject);
            }
        }
    }

    private void DealDamageToPlayer(GameObject playerObject)
    {
        lastAttackTime = Time.time;
        HealtyBar playerHealth = playerObject.GetComponent<HealtyBar>();
        if (playerHealth != null)
        {
            playerHealth.can -= damage;
            if (playerHealth.can < 0)
            {
                playerHealth.can = 0;
                // Player ölümü ile ilgili iþlemler burada yapýlabilir.
                Debug.Log("Player Died");
            }
        }
    }
}

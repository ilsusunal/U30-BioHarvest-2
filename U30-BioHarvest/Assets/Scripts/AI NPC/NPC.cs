using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    //[SerializeField] private GameObject destinationPoint;
    //
    //private NavMeshAgent _agent;
    //void Start()
    //{
    //    
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}
    public NavMeshAgent _agent;
    [SerializeField] Transform _player;
    public LayerMask ground, player;

    public Vector3 destinationPoint;
    private bool destinationPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public GameObject sphere;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        //patrol / chase / Attack
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
    void Patroling()
    {
        if (!destinationPointSet)
        {
            SearcWalkPoint();
        }
        if (destinationPointSet) 
        {
            _agent.SetDestination(destinationPoint);
        }
        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if (distanceToDestinationPoint.magnitude < 1.0f)
        {
            destinationPointSet = false;
        }
    }
    void SearcWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkPointRange,walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange,walkPointRange);
        
        destinationPoint = new Vector3 (x:transform.position.x + randomX, transform.position.y,
            z:transform.position.z + randomZ);
        if (Physics.Raycast(origin:destinationPoint, direction:-transform.up, maxDistance:2.0f, (int)ground))
        {
            destinationPointSet = true;
        }
    }
    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
    void AttackPlayer()
    {
        _agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse); //Ýleri
            rb.AddForce(transform.up * 7f, ForceMode.Impulse); //yukarý

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAI : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints; // Ar�n�n devriye gezece�i noktalar
    [SerializeField] private float patrolSpeed = 3.5f; // Devriye h�z�n� belirler
    [SerializeField] private float attackRange = 10f; // Sald�r� mesafesi
    [SerializeField] private GameObject stingerPrefab; // ��ne prefab'i
    [SerializeField] private Transform stingerSpawnPoint; // ��nenin ��kaca�� nokta
    [SerializeField] private float stingerSpeed = 50f; // ��nenin h�z�
    [SerializeField] private float timeBetweenAttacks = 2f; // Sald�r�lar aras�ndaki s�re
    [SerializeField] private float rotationSpeed = 5f; // Ar�n�n oyuncuya d�nerkenki rotasyon h�z�

    private NavMeshAgent agent; // Ar�n�n hareketini kontrol eden NavMesh agent
    private int currentPatrolIndex; // �u anki devriye noktas�
    private Transform player; // Oyuncunun transformu
    private bool isAttacking; // Ar�n�n �u anda sald�r�da olup olmad���n� belirler

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�enini al�r
        agent.speed = patrolSpeed; // NavMeshAgent h�z�n� ayarlar
        agent.autoBraking = false; // Hedefe ula��nca durmay� engeller
        currentPatrolIndex = 0; // �lk devriye noktas�n� ayarlar
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun transformunu al�r

        GoToNextPatrolPoint(); // �lk devriye noktas�na gider
    }

    void Update()
    {
        if (!isAttacking) // E�er sald�r�da de�ilse
        {
            Patrol(); // Devriye fonksiyonunu �a��r
        }

        if (Vector3.Distance(player.position, transform.position) <= attackRange) // Oyuncu sald�r� mesafesindeyse
        {
            Attack(); // Sald�r� fonksiyonunu �a��r
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending) // E�er hedefe ula��ld�ysa ve yeni bir yol hesaplanm�yorsa
        {
            GoToNextPatrolPoint(); // Bir sonraki devriye noktas�na git
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) // E�er devriye noktalar� yoksa
            return;

        agent.destination = patrolPoints[currentPatrolIndex].position; // �u anki devriye noktas�na git

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Bir sonraki devriye noktas�n� ayarlar
    }

    void Attack()
    {
        if (!isAttacking) // E�er zaten sald�r�da de�ilse
        {
            isAttacking = true; // Sald�r� durumunu ayarla
            agent.isStopped = true; // NavMeshAgent'� durdur
            StartCoroutine(ShootStinger()); // ��ne f�rlatma coroutine'ini ba�lat
        }
    }

    IEnumerator ShootStinger()
    {
        while (Vector3.Distance(player.position, transform.position) <= attackRange) // Oyuncu sald�r� mesafesindeyken
        {
            // Ar�n�n y�n�n� oyuncuya do�ru d�nd�r
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // ��ne f�rlatma i�lemi
            GameObject stinger = Instantiate(stingerPrefab, stingerSpawnPoint.position, Quaternion.identity); // ��ne prefab'ini olu�tur
            Rigidbody rb = stinger.GetComponent<Rigidbody>(); // ��ne prefab'inin Rigidbody bile�enini al
            if (rb != null) // E�er Rigidbody varsa
            {
                rb.velocity = (player.position - stingerSpawnPoint.position).normalized * stingerSpeed; // ��neyi oyuncuya do�ru f�rlat
            }
            else
            {
                Debug.LogWarning("Rigidbody not found on stingerPrefab!"); // Rigidbody bulunamad�ysa uyar� mesaj� g�ster
            }
            yield return new WaitForSeconds(timeBetweenAttacks); // Sald�r�lar aras�ndaki s�reyi bekle
        }

        isAttacking = false; // Sald�r� durumunu kapat
        agent.isStopped = false; // NavMeshAgent'� yeniden ba�lat
    }
}

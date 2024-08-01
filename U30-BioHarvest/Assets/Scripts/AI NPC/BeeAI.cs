using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAI : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints; // Arýnýn devriye gezeceði noktalar
    [SerializeField] private float patrolSpeed = 3.5f; // Devriye hýzýný belirler
    [SerializeField] private float attackRange = 10f; // Saldýrý mesafesi
    [SerializeField] private GameObject stingerPrefab; // Ýðne prefab'i
    [SerializeField] private Transform stingerSpawnPoint; // Ýðnenin çýkacaðý nokta
    [SerializeField] private float stingerSpeed = 50f; // Ýðnenin hýzý
    [SerializeField] private float timeBetweenAttacks = 2f; // Saldýrýlar arasýndaki süre
    [SerializeField] private float rotationSpeed = 5f; // Arýnýn oyuncuya dönerkenki rotasyon hýzý

    private NavMeshAgent agent; // Arýnýn hareketini kontrol eden NavMesh agent
    private int currentPatrolIndex; // Þu anki devriye noktasý
    private Transform player; // Oyuncunun transformu
    private bool isAttacking; // Arýnýn þu anda saldýrýda olup olmadýðýný belirler

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþenini alýr
        agent.speed = patrolSpeed; // NavMeshAgent hýzýný ayarlar
        agent.autoBraking = false; // Hedefe ulaþýnca durmayý engeller
        currentPatrolIndex = 0; // Ýlk devriye noktasýný ayarlar
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun transformunu alýr

        GoToNextPatrolPoint(); // Ýlk devriye noktasýna gider
    }

    void Update()
    {
        if (!isAttacking) // Eðer saldýrýda deðilse
        {
            Patrol(); // Devriye fonksiyonunu çaðýr
        }

        if (Vector3.Distance(player.position, transform.position) <= attackRange) // Oyuncu saldýrý mesafesindeyse
        {
            Attack(); // Saldýrý fonksiyonunu çaðýr
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending) // Eðer hedefe ulaþýldýysa ve yeni bir yol hesaplanmýyorsa
        {
            GoToNextPatrolPoint(); // Bir sonraki devriye noktasýna git
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) // Eðer devriye noktalarý yoksa
            return;

        agent.destination = patrolPoints[currentPatrolIndex].position; // Þu anki devriye noktasýna git

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Bir sonraki devriye noktasýný ayarlar
    }

    void Attack()
    {
        if (!isAttacking) // Eðer zaten saldýrýda deðilse
        {
            isAttacking = true; // Saldýrý durumunu ayarla
            agent.isStopped = true; // NavMeshAgent'ý durdur
            StartCoroutine(ShootStinger()); // Ýðne fýrlatma coroutine'ini baþlat
        }
    }

    IEnumerator ShootStinger()
    {
        while (Vector3.Distance(player.position, transform.position) <= attackRange) // Oyuncu saldýrý mesafesindeyken
        {
            // Arýnýn yönünü oyuncuya doðru döndür
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Ýðne fýrlatma iþlemi
            GameObject stinger = Instantiate(stingerPrefab, stingerSpawnPoint.position, Quaternion.identity); // Ýðne prefab'ini oluþtur
            Rigidbody rb = stinger.GetComponent<Rigidbody>(); // Ýðne prefab'inin Rigidbody bileþenini al
            if (rb != null) // Eðer Rigidbody varsa
            {
                rb.velocity = (player.position - stingerSpawnPoint.position).normalized * stingerSpeed; // Ýðneyi oyuncuya doðru fýrlat
            }
            else
            {
                Debug.LogWarning("Rigidbody not found on stingerPrefab!"); // Rigidbody bulunamadýysa uyarý mesajý göster
            }
            yield return new WaitForSeconds(timeBetweenAttacks); // Saldýrýlar arasýndaki süreyi bekle
        }

        isAttacking = false; // Saldýrý durumunu kapat
        agent.isStopped = false; // NavMeshAgent'ý yeniden baþlat
    }
}

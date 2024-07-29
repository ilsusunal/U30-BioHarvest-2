using UnityEngine;
using UnityEngine.AI;

public class SlimeMovement : MonoBehaviour
{
    public float wanderRadius = 10f; // Gezme yar��ap� (slime'lar�n rastgele olarak gidebilece�i alan�n yar��ap�)
    public float wanderTimer = 5f; // Gezme zamanlay�c�s� (slime'lar�n ne s�kl�kta yeni bir hedef noktaya gidece�i)

    private Transform target; // Hedef konum
    private NavMeshAgent agent; // Slime karakterine eklenen NavMeshAgent komponenti
    private float timer; // Zamanlay�c�

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent komponentini al
        timer = wanderTimer; // Zamanlay�c�y� ba�lang�� de�erine ayarla
    }

    void Update()
    {
        timer += Time.deltaTime; // Zamanlay�c�y� g�ncelle

        if (timer >= wanderTimer) // Zamanlay�c� belirlenen s�reyi ge�tiyse
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1); // Yeni rastgele bir hedef konum belirle
            agent.SetDestination(newPos); // NavMeshAgent'a yeni hedef konumu ayarla
            timer = 0; // Zamanlay�c�y� s�f�rla
        }
    }

    // Rastgele bir hedef konum belirleyen fonksiyon
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist; // Rastgele bir y�n belirle
        randDirection += origin; // Rastgele y�n� orijin noktas�na ekle

        NavMeshHit navHit; // NavMeshHit de�i�keni olu�tur

        // Belirlenen rastgele konumun ge�erli bir NavMesh pozisyonu olup olmad���n� kontrol et
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position; // Ge�erli NavMesh pozisyonunu geri d�nd�r
    }
}

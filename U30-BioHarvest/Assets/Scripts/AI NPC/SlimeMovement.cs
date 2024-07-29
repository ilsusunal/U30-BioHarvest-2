using UnityEngine;
using UnityEngine.AI;

public class SlimeMovement : MonoBehaviour
{
    public float wanderRadius = 10f; // Gezme yarýçapý (slime'larýn rastgele olarak gidebileceði alanýn yarýçapý)
    public float wanderTimer = 5f; // Gezme zamanlayýcýsý (slime'larýn ne sýklýkta yeni bir hedef noktaya gideceði)

    private Transform target; // Hedef konum
    private NavMeshAgent agent; // Slime karakterine eklenen NavMeshAgent komponenti
    private float timer; // Zamanlayýcý

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent komponentini al
        timer = wanderTimer; // Zamanlayýcýyý baþlangýç deðerine ayarla
    }

    void Update()
    {
        timer += Time.deltaTime; // Zamanlayýcýyý güncelle

        if (timer >= wanderTimer) // Zamanlayýcý belirlenen süreyi geçtiyse
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1); // Yeni rastgele bir hedef konum belirle
            agent.SetDestination(newPos); // NavMeshAgent'a yeni hedef konumu ayarla
            timer = 0; // Zamanlayýcýyý sýfýrla
        }
    }

    // Rastgele bir hedef konum belirleyen fonksiyon
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist; // Rastgele bir yön belirle
        randDirection += origin; // Rastgele yönü orijin noktasýna ekle

        NavMeshHit navHit; // NavMeshHit deðiþkeni oluþtur

        // Belirlenen rastgele konumun geçerli bir NavMesh pozisyonu olup olmadýðýný kontrol et
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position; // Geçerli NavMesh pozisyonunu geri döndür
    }
}

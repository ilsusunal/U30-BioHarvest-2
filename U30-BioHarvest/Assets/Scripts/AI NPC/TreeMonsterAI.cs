using UnityEngine;

public class TreeMonsterAI : MonoBehaviour
{
    public GameObject player; // Oyuncu karakterini temsil eden oyun nesnesi
    public GameObject axePrefab; // Baltanýn prefab modeli
    public Transform axeSpawnPoint; // Baltanýn fýrlatýlacaðý nokta
    public float detectionRange = 10f; // Oyuncunun algýlanacaðý mesafe
    public float attackCooldown = 2f; // Saldýrýlarýn arasýndaki bekleme süresi
    public float axeSpeed = 10f; // Baltanýn hedefe giderkenki hýzý
    public float spinSpeed = 1000f; // Baltanýn dönüþ hýzý

    private bool playerInRange; // Oyuncunun algýlanýp algýlanmadýðýný belirten bayrak
    private float nextAttackTime; // Bir sonraki saldýrý zamaný

    void Update()
    {
        // Oyuncuyu algýla
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange) // Oyuncu algýlama mesafesindeyse
        {
            playerInRange = true; // Oyuncu algýlandý olarak ayarla
        }
        else
        {
            playerInRange = false; // Oyuncu algýlanmadý olarak ayarla
        }

        // Oyuncu algýlandýðýnda saldýr
        if (playerInRange && Time.time >= nextAttackTime) // Oyuncu algýlandýysa ve saldýrý bekleme süresi geçtiyse
        {
            AttackPlayer(); // Oyuncuya saldýr
            nextAttackTime = Time.time + attackCooldown; // Bir sonraki saldýrý zamanýný güncelle
        }
    }

    void AttackPlayer()
    {
        // Baltayý oluþtur ve oyuncuya fýrlat
        GameObject axe = Instantiate(axePrefab, axeSpawnPoint.position, axeSpawnPoint.rotation); // Baltanýn yeni bir örneðini oluþtur
        Rigidbody rb = axe.GetComponent<Rigidbody>(); // Baltanýn Rigidbody bileþenini al
        rb.velocity = (player.transform.position - axeSpawnPoint.position).normalized * axeSpeed; // Baltayý oyuncuya doðru fýrlat ve hýzýný ayarla

        // Dönüþ kuvveti ekle (-X ekseni etrafýnda)
        rb.angularVelocity = new Vector3(-spinSpeed, 0f, 0f); // Baltanýn -X ekseni etrafýnda dönmesini saðla
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // Çarpýþan nesne oyuncuysa
        {
            playerInRange = true; // Oyuncu algýlandý olarak ayarla
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) // Çarpýþma alanýndan çýkan nesne oyuncuysa
        {
            playerInRange = false; // Oyuncu algýlanmadý olarak ayarla
        }
    }
}

using UnityEngine;

public class TreeMonsterAI : MonoBehaviour
{
    public GameObject player; // Oyuncu karakterini temsil eden oyun nesnesi
    public GameObject axePrefab; // Baltan�n prefab modeli
    public Transform axeSpawnPoint; // Baltan�n f�rlat�laca�� nokta
    public float detectionRange = 10f; // Oyuncunun alg�lanaca�� mesafe
    public float attackCooldown = 2f; // Sald�r�lar�n aras�ndaki bekleme s�resi
    public float axeSpeed = 10f; // Baltan�n hedefe giderkenki h�z�
    public float spinSpeed = 1000f; // Baltan�n d�n�� h�z�

    private bool playerInRange; // Oyuncunun alg�lan�p alg�lanmad���n� belirten bayrak
    private float nextAttackTime; // Bir sonraki sald�r� zaman�

    void Update()
    {
        // Oyuncuyu alg�la
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange) // Oyuncu alg�lama mesafesindeyse
        {
            playerInRange = true; // Oyuncu alg�land� olarak ayarla
        }
        else
        {
            playerInRange = false; // Oyuncu alg�lanmad� olarak ayarla
        }

        // Oyuncu alg�land���nda sald�r
        if (playerInRange && Time.time >= nextAttackTime) // Oyuncu alg�land�ysa ve sald�r� bekleme s�resi ge�tiyse
        {
            AttackPlayer(); // Oyuncuya sald�r
            nextAttackTime = Time.time + attackCooldown; // Bir sonraki sald�r� zaman�n� g�ncelle
        }
    }

    void AttackPlayer()
    {
        // Baltay� olu�tur ve oyuncuya f�rlat
        GameObject axe = Instantiate(axePrefab, axeSpawnPoint.position, axeSpawnPoint.rotation); // Baltan�n yeni bir �rne�ini olu�tur
        Rigidbody rb = axe.GetComponent<Rigidbody>(); // Baltan�n Rigidbody bile�enini al
        rb.velocity = (player.transform.position - axeSpawnPoint.position).normalized * axeSpeed; // Baltay� oyuncuya do�ru f�rlat ve h�z�n� ayarla

        // D�n�� kuvveti ekle (-X ekseni etraf�nda)
        rb.angularVelocity = new Vector3(-spinSpeed, 0f, 0f); // Baltan�n -X ekseni etraf�nda d�nmesini sa�la
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // �arp��an nesne oyuncuysa
        {
            playerInRange = true; // Oyuncu alg�land� olarak ayarla
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) // �arp��ma alan�ndan ��kan nesne oyuncuysa
        {
            playerInRange = false; // Oyuncu alg�lanmad� olarak ayarla
        }
    }
}

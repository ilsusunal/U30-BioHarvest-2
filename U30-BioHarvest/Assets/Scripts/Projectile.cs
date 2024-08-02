using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;

    private void Start()
    {
        // Belirli bir s�re sonra hedefleme i�lemini ba�lat
        Destroy(gameObject, 10f);  // Topun ya�am s�resi
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))

        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);

        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
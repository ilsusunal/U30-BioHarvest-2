using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float launchForce = 10f;
    public float fireInterval = 5f;  // Topun her 5 saniyede bir atýlmasýný saðlar

    private float timeSinceLastFire = 0f;

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && timeSinceLastFire >= fireInterval)
        {
            LaunchProjectile(other.transform);
            timeSinceLastFire = 0f;  // Zamanlayýcýyý sýfýrla
        }
    }

    private void LaunchProjectile(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (target.position - shootPoint.position).normalized;
            rb.AddForce(direction * launchForce, ForceMode.Impulse);
        }
    }
}

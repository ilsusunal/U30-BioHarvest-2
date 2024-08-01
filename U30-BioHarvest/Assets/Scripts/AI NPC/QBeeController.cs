using System.Collections;
using UnityEngine;

public class QBeeController : MonoBehaviour
{
    public Transform[] escapePoints;  // Kaçýþ noktalarý
    public float moveSpeed = 5f;      // Hareket hýzý
    public float waitTime = 1f;       // Bekleme süresi
    public float rotationSpeed = 5f;  // Dönüþ hýzý

    private int currentPointIndex = 0;
    private bool isWaiting = false;

    private void Start()
    {
        if (escapePoints.Length > 0)
        {
            StartCoroutine(MoveToPoints());
        }
    }

    private IEnumerator MoveToPoints()
    {
        while (true)
        {
            if (!isWaiting)
            {
                Transform targetPoint = escapePoints[currentPointIndex];
                Vector3 direction = (targetPoint.position - transform.position).normalized;

                // Yön hesaplama ve modelin hedefe dönmesi
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                    yield return null;
                }

                // Modelin hedefe hareket etmesini saðlayýn
                while (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    yield return null;
                }

                // Hedef noktaya ulaþýldýðýnda bekleme süresi
                isWaiting = true;
                yield return new WaitForSeconds(waitTime);
                isWaiting = false;

                // Sonraki kaçýþ noktasýna geçiþ
                currentPointIndex = (currentPointIndex + 1) % escapePoints.Length;
            }

            yield return null;
        }
    }
}

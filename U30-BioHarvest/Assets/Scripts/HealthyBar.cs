using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtyBar : MonoBehaviour
{
    public float can, animasyonYavasligi;
    private float maxCan;

    public Slider healthSlider; // UI Slider referans�

    void Start()
    {
        maxCan = can;
        healthSlider.maxValue = maxCan; // Slider'�n maksimum de�erini ayarla
        healthSlider.value = can; // Slider'� ba�lang�� can de�erine ayarla
    }

    void Update()
    {
        // Sa�l�k �ubu�unu yava��a k���lmesini sa�layan animasyon
        if (transform.localScale.x > can / maxCan)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x - can / maxCan) / animasyonYavasligi, transform.localScale.y, transform.localScale.z);
        }

        // Test ama�l� klavyeden can azaltma
        if (Input.GetKeyDown("h"))
        {
            AzaltCan(10);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            Debug.Log("Suya dokundu");
            AzaltCan(10);
        }
    }

    // Can de�erini azaltan ve UI Slider'� g�ncelleyen metod
    void AzaltCan(float miktar)
    {
        can -= miktar;
        if (can < 0) can = 0;
        healthSlider.value = can; // Can de�eri de�i�ti�inde Slider'� g�ncelle
    }

}
